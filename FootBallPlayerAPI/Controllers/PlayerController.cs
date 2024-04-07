using AutoMapper;
using FootballPlayerAPI.Data;
using FootballPlayerAPI.Entities;
using FootballPlayerAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballPlayerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly FootballPlayerDbContext _context;
        private readonly IMapper _mapper;

        public PlayerController(FootballPlayerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get(int pageIndex = 0, int pageSize = 10)
        {
            BaseResponseModel response = new BaseResponseModel();

            try
            {
                var PlayerCount = _context.Players.Count();
                var PlayerList =_mapper.Map<List<PlayerListViewModel>>(_context.Players.Skip(pageIndex * pageSize).Take(pageSize).ToList());

                response.Status = true;
                response.Message = "Success";
                response.Data = new { Players = PlayerList, Count = PlayerCount };

                return Ok(response);
            }
            catch (Exception exp)
            {
                response.Status = false;
                response.Message = "Something went wrong";

                return BadRequest(response);
            }
            
        }

        [HttpGet("{id}")]
        public IActionResult GetFootballPlayerById(int id)
        {
            BaseResponseModel response = new BaseResponseModel();

            try
            {
                var Player = _context.Players.Where(x => x.Id == id).FirstOrDefault();

                if (Player == null)
                {
                    response.Status = false;
                    response.Message = "Record Not Found";

                    return BadRequest(response);
                }

                var playerData = _mapper.Map<PlayerListViewModel>(Player);

                response.Status = true;
                response.Message = "Success";
                response.Data = playerData;

                return Ok(response);
            }
            catch (Exception exp)
            {
                response.Status = false;
                response.Message = "Something went wrong";

                return BadRequest(response);
            }

        }

        [HttpGet]
        [Route("Search/{searchText}")]
        public IActionResult GetFootballPlayerByText(string searchText)
        {
            BaseResponseModel response = new BaseResponseModel();

            try
            {
                var searchedPlayer = _context.Players.Where(x => x.BirthPlace.Contains(searchText));

                var playerData = _mapper.Map<List<PlayerListViewModel>>(searchedPlayer.ToList());

                response.Status = true;
                response.Message = "Success";
                response.Data = playerData;

                return Ok(response);
            }
            catch (Exception exp)
            {
                response.Status = false;
                response.Message = "Something went wrong";

                return BadRequest(response);
            }
        }

        [HttpPost]
        public IActionResult Post(CreatePlayerViewModel model)
        {
            BaseResponseModel response = new BaseResponseModel();

            try
            {
                if (ModelState.IsValid)
                {
                    var postedModel = _mapper.Map<Player>(model);

                    _context.Players.Add(postedModel);
                    _context.SaveChanges();

                    var responseData = _mapper.Map<PlayerListViewModel>(postedModel);

                    response.Status = true;
                    response.Message = "Created Succesfully";
                    response.Data = responseData;

                    return Ok(response);
                }
                else
                {
                    response.Status = false;
                    response.Message = "Validation failed.";
                    response.Data = ModelState;

                    return BadRequest(response);
                }
            }
            catch (Exception exp)
            {
                response.Status = false;
                response.Message = "Something went wrong";

                return BadRequest(response);
            }
        }

        [HttpPut]
        public IActionResult Put(CreatePlayerViewModel model)
        {
            BaseResponseModel response = new BaseResponseModel();

            try
            {
                if (ModelState.IsValid)
                {
                    if (model.Id <= 0)
                    {
                        response.Status = false;
                        response.Message = "Invalid Player Recorded.";

                        return BadRequest(response);
                    }

                    var playerDetail = _context.Players.Where(x => x.Id == model.Id).FirstOrDefault();

                    if (playerDetail == null)
                    {
                        response.Status = false;
                        response.Message = "Invalid Player Recorded.";

                        return BadRequest(response);
                    }

                    playerDetail.Name = model.Name;
                    playerDetail.Age = model.Age;
                    playerDetail.BirthPlace = model.BirthPlace;

                    _context.SaveChanges();

                    var responseData = new PlayerListViewModel
                    {
                        Id = playerDetail.Id,
                        Name = playerDetail.Name,
                        Age = playerDetail.Age,
                        BirthPlace = playerDetail.BirthPlace
                    };

                    response.Status = true;
                    response.Message = "Updated Succesfully";
                    response.Data = playerDetail;

                    return Ok(response);
                }
                else
                {
                    response.Status = false;
                    response.Message = "Validation failed.";
                    response.Data = ModelState;

                    return BadRequest(response);
                }
            }
            catch (Exception exp)
            {
                response.Status = false;
                response.Message = "Something went wrong";

                return BadRequest(response);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            BaseResponseModel response = new BaseResponseModel();

            try
            {
                var Player = _context.Players.Where(x => x.Id == id).FirstOrDefault();

                if (Player == null)
                {
                    response.Status = false;
                    response.Message = "Invalid Player Recorded.";

                    return BadRequest(response);
                }

                _context.Players.Remove(Player);
                _context.SaveChanges();

                response.Status = true;
                response.Message = "Deleted Successfully";

                return Ok(response);
            }
            catch (Exception exp)
            {
                response.Status = false;
                response.Message = "Something went wrong";

                return BadRequest(response);
            }
        }
    }
}
