using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MidAssignment_ZeroHunger.DTOs;
using MidAssignment_ZeroHunger.EF;

namespace MidAssignment_ZeroHunger.Controllers
{
    public class RestaurantsController : Controller
    {
        public static List<RestaurantsDTO> Convert(List<Restaurant> data)
        {
            var list = new List<RestaurantsDTO>();
            foreach (var item in data)
            {
                list.Add(Convert(item));
            }
            return list;
        }
        public static RestaurantsDTO Convert(Restaurant r)
        {
            return new RestaurantsDTO()
            {
                ResId = r.ResId,
                ResName = r.ResName,
                ResAddress = r.ResAddress,
                ResContact = r.ResContact,
                ResPass = r.ResPass,
                ResUser = r.ResUser,
                NgoId = r.NgoId
            };
        }
        public static Restaurant Convert(RestaurantsDTO r)
        {
            return new Restaurant()
            {
                ResId = r.ResId,
                ResName = r.ResName,
                ResAddress = r.ResAddress,
                ResContact = r.ResContact,
                ResPass = r.ResPass,
                ResUser = r.ResUser,
                NgoId = 1
            };
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RestaurantsDTO r)
        {
            if (ModelState.IsValid)
            {
                var db = new MidAssignmentEntities();
                db.Restaurants.Add(Convert(r));
                db.SaveChanges();
                TempData["Msg"] = "Registration successful";
                return RedirectToAction("Login");
            }
            var db2 = new MidAssignmentEntities();
            ViewBag.Restaurants = db2.Restaurants.ToList();
            return View();
        }

        public ActionResult Login()
        {
            if (Session["LoggedInRestaurantUser"] != null)
            {
                return RedirectToAction("Dashboard");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(RestaurantsDTO restaurant)
        {
            var db = new MidAssignmentEntities();
            var loggedInRestaurant = db.Restaurants.FirstOrDefault(res => res.ResUser == restaurant.ResUser && res.ResPass == restaurant.ResPass);
            if (loggedInRestaurant != null)
            {
                Session["LoggedInRestaurantId"] = loggedInRestaurant.ResId;
                Session["LoggedInRestaurantName"] = loggedInRestaurant.ResName;
                return RedirectToAction("Dashboard");
            }
            ModelState.AddModelError("", "Invalid username or password");
            return View(restaurant);
        }
        public ActionResult Dashboard()
        {
            var db = new MidAssignmentEntities();
            var LoggedInRestaurantId = (int)Session["LoggedInRestaurantId"];
            var LoggedInRestaurantName = (string)Session["LoggedInRestaurantName"];
            var allRestaurants = db.Restaurants.ToList();
            return View(Convert(allRestaurants));
        }

        public static List<CollectRequestDTO> Convert(List<Collect_Request> data)
        {
            var list = new List<CollectRequestDTO>();
            foreach (var item in data)
            {
                list.Add(Convert(item));
            }
            return list;
        }
        public static CollectRequestDTO Convert(Collect_Request cr)
        {
            return new CollectRequestDTO()
            {
                CollectReqId = cr.CollectReqId,
                Food_Name = cr.Food_Name,
                Food_Description = cr.Food_Description,
                Food_Quantity = cr.Food_Quantity,
                Preservation_Time = cr.Preservation_Time,
                Request_Time = cr.Request_Time,
                Distribution_Status = cr.Distribution_Status
            };
        }

        public ActionResult ShowCollectionRequest()
        {
            var db = new MidAssignmentEntities();
            var loggedInRestaurantId = (int)Session["LoggedInRestaurantId"];
            var restaurantRequests = db.Collect_Requests
                                        .Where(cr => cr.RestaurantsId == loggedInRestaurantId)
                                        .ToList();
            var requestDTOs = Convert(restaurantRequests);
            return View(requestDTOs);
        }


        [HttpPost]
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();

            return RedirectToAction("Login");
        }

        public ActionResult CreateCollectRequest()
        {
            if (Session != null && Session["LoggedInRestaurantId"] != null)
            {
                var loggedInRestaurantId = (int)Session["LoggedInRestaurantId"];

                var collectRequest = new CollectRequestDTO
                {
                    RestaurantsId = loggedInRestaurantId,
                    Employee_Status = "Unassigned",
                    Distribution_Status = "Incomplete",
                    Request_Time = DateTime.Now,
                };

                return View(collectRequest);
            }
            else
            {
                return RedirectToAction("Login", "Restaurants");
            }
        }

        [HttpPost]
        public ActionResult CreateCollectRequest(CollectRequestDTO collectRequest)
        {
            if (ModelState.IsValid)
            {
                var db = new MidAssignmentEntities();
                var collectRequestEntity = ConvertToEntity(collectRequest);
                db.Collect_Requests.Add(collectRequestEntity);
                db.SaveChanges();
                TempData["Msg"] = "Collection Request Created Successfully";
                return RedirectToAction("Dashboard");
            }

            return View(collectRequest);
        }
        private Collect_Request ConvertToEntity(CollectRequestDTO dto)
        {
            return new Collect_Request
            {
                CollectReqId = dto.CollectReqId,
                RestaurantsId = dto.RestaurantsId,
                Food_Name = dto.Food_Name,
                Food_Description = dto.Food_Description,
                Food_Quantity = dto.Food_Quantity,
                Preservation_Time = dto.Preservation_Time,
                Request_Time = dto.Request_Time,
                Employee_Status = dto.Employee_Status,
                Employee_id = 1,
                Distribution_Status = dto.Distribution_Status,
                NgoId = 1
            };
        }
    }
}