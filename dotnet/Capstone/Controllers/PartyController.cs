﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.DAO;
using Capstone.Models;
using RestSharp;
using Capstone.Services;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PartyController : ControllerBase
    {
        private readonly string connectionString;
        // TODO: add partyDao, guestsDAO, restaurantDAO
        private IPartyDao PartyDao = new PartySqlDao("Server=.\\SQLEXPRESS;Database=final_capstone;Trusted_Connection=True;");
        private IGuestDao GuestsDao = new GuestSqlDao("Server=.\\SQLEXPRESS;Database=final_capstone;Trusted_Connection=True;");
        private IRestaurantDao RestaurantsDao = new RestaurantSqlDao("Server=.\\SQLEXPRESS;Database=final_capstone;Trusted_Connection=True;");




        //PartyController()
        //{
        //    //PartyDao = new PartySqlDao(dbConnectionString);
        //    //GuestsDao = new GuestSqlDao(dbConnectionString);
        //    //RestaurantsDao = new RestaurantSqlDao(dbConnectionString);
        //}
        // GET /<PartyController>/5
        [HttpGet]
        public IList<PartyViewModel> Get()
        {
            //Here we Call "GetParty" in partySqlDAO, "GetRestaurants" from restaurantDAO, "GetGuests" from guestsDAO
            IList<Party> parties = PartyDao.GetParties(1);
            //make partyviewmodel from values above. 
            // A viewModel is the model of data returned to the view
            IList<PartyViewModel> partyViewModels = new List<PartyViewModel>();
            foreach (var party in parties)
            {
                PartyViewModel partyGuestsAndRestaurants = new PartyViewModel(party, new List<Guest>(), new List<Restaurant>());
                partyViewModels.Add(partyGuestsAndRestaurants);
            }
            return partyViewModels;
        }

        //PartyController()
        //{
        //    //PartyDao = new PartySqlDao(dbConnectionString);
        //    //GuestsDao = new GuestSqlDao(dbConnectionString);
        //    //RestaurantsDao = new RestaurantSqlDao(dbConnectionString);
        //}
        // GET /<PartyController>/5
        [HttpGet("{partyId}")]
        public PartyViewModel Get(int partyId)
        {
            //Here we Call "GetParty" in partySqlDAO, "GetRestaurants" from restaurantDAO, "GetGuests" from guestsDAO
            Party party = PartyDao.GetParty(partyId);
            IList<Restaurant> restaurants = RestaurantsDao.GetRestaurants(partyId);
            IList<Guest> guests = GuestsDao.GetGuests(partyId);
            //make partyviewmodel from values above. 
            // A viewModel is the model of data returned to the view
            PartyViewModel partyGuestsAndRestaurants = new PartyViewModel(party, guests, restaurants);
            return partyGuestsAndRestaurants;
        }



        [HttpGet("{partyId}/restaurants")]
        public List<RestaurantViewModel> GetRestaurants(int partyId)
        {
            //TODO CALL THIS FROM PARTSERVICE IN VUE
            YelpApiService yelpService = new YelpApiService();
            return yelpService.CreatePracticeRestaurants();
        }

        /// POST /<PartyController>
        /// 
        [HttpPost]
        public int Post([FromBody] Party updatedParty)
        {
            //Use partyDao.CreateParty(newParty) to create a new party, and return the ID of the party
            
            // newPartyId is the Id of the newly created part
            Party newParty = new Party();
            newParty.Name = updatedParty.Name;
            newParty.Date = updatedParty.Date;
            newParty.Owner = updatedParty.Owner;
            newParty.Location = updatedParty.Location;
            newParty.Description = updatedParty.Description;
            newParty.InviteLink = "https://localhost:44315/tinder/{partyId}";

            int newPartyId = PartyDao.CreateParty(newParty).PartyId;
            return newPartyId;
        }

        // PUT /<PartyController>/5
        [HttpPut("{updatedPartyId}")]
        public void Put(int updatedPartyId, [FromBody] Party updatedParty)
        {
            //TODO: Setup + Call "UpdateParty()" in partySqlDAO that takes in a updatedPartyId and updates the party where party_Id = updatedPartyId
        }

        // DELETE /<PartyController>/5
        [HttpDelete("{partyId}")]
        public void Delete(int partyId)
        {
            //TODO: Setup + Call "DeleteParty()" in partySqlDAO that takes in a partyId and deletes the party where party_Id = partyId
        }

        /// POST /<PartyController>/location
        /// 
        //public IList<Restaurant> Post([FromBody] string zipcode)
        //{
        //    //TODO: CALL YELP API AND GET 25 Restaurants AND DETAILS FROM ZIP CODE
        //    //
        //    var client = new RestClient("https://api.yelp.com/v3/businesses/search?sort_by=best_match&limit=20");
        //    var request = new RestRequest(Method.GET);
        //    request.AddHeader("accept", "application/json");
        //    IRestResponse response = client.Execute(request);

        //    throw new NotImplementedException();
        //}

       
    }
}