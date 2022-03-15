using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using TEKenable.ProjectTemplate.Web.Models.Demo;

namespace TEKenable.ProjectTemplate.Web.Controllers
{
    public class ControlTypeDemoController : Controller
    {
        private static Dictionary<int, string> _List;
        private static List<SelectListItem> _ListItems;

        public ControlTypeDemoController()
        {
            if (_List == null)
            {
                Assembly currentAssem = Assembly.GetExecutingAssembly();
                int i = 1;
                Dictionary<int, string> list = new Dictionary<int, string>();
                foreach (Type type in currentAssem.GetTypes())
                {
                    if (!list.ContainsValue(type.Name))
                        list.Add(i++, type.Name);
                    PropertyInfo[] pi = type.GetProperties();
                    foreach (PropertyInfo prop in pi)
                        if (!list.ContainsValue(prop.Name))
                            list.Add(i++, prop.Name);
                }
                _List = list;
            }

            if (_ListItems == null)
            {
                _ListItems = new List<SelectListItem>()
                {
                    new SelectListItem(){Value="AK", Text = "Alaska"            },
                    new SelectListItem(){Value="HI", Text = "Hawaii"            },
                    new SelectListItem(){Value="CA", Text = "California"        },
                    new SelectListItem(){Value="NV", Text = "Nevada"            },
                    new SelectListItem(){Value="OR", Text = "Oregon"            },
                    new SelectListItem(){Value="WA", Text = "Washington"        },
                    new SelectListItem(){Value="AZ", Text = "Arizona"           },
                    new SelectListItem(){Value="CO", Text = "Colorado"          },
                    new SelectListItem(){Value="ID", Text = "Idaho"             },
                    new SelectListItem(){Value="MT", Text = "Montana"           },
                    new SelectListItem(){Value="NE", Text = "Nebraska"          },
                    new SelectListItem(){Value="NM", Text = "New Mexico"        },
                    new SelectListItem(){Value="ND", Text = "North Dakota"      },
                    new SelectListItem(){Value="UT", Text = "Utah"              },
                    new SelectListItem(){Value="WY", Text = "Wyoming"           },
                    new SelectListItem(){Value="AL", Text = "Alabama"           },
                    new SelectListItem(){Value="AR", Text = "Arkansas"          },
                    new SelectListItem(){Value="IL", Text = "Illinois"          },
                    new SelectListItem(){Value="IA", Text = "Iowa"              },
                    new SelectListItem(){Value="KS", Text = "Kansas"            },
                    new SelectListItem(){Value="KY", Text = "Kentucky"          },
                    new SelectListItem(){Value="LA", Text = "Louisiana"         },
                    new SelectListItem(){Value="MN", Text = "Minnesota"         },
                    new SelectListItem(){Value="MS", Text = "Mississippi"       },
                    new SelectListItem(){Value="MO", Text = "Missouri"          },
                    new SelectListItem(){Value="OK", Text = "Oklahoma"          },
                    new SelectListItem(){Value="SD", Text = "South Dakota"      },
                    new SelectListItem(){Value="TX", Text = "Texas"             },
                    new SelectListItem(){Value="TN", Text = "Tennessee"         },
                    new SelectListItem(){Value="WI", Text = "Wisconsin"         },
                    new SelectListItem(){Value="CT", Text = "Connecticut"       },
                    new SelectListItem(){Value="DE", Text = "Delaware"          },
                    new SelectListItem(){Value="FL", Text = "Florida"           },
                    new SelectListItem(){Value="GA", Text = "Georgia"           },
                    new SelectListItem(){Value="IN", Text = "Indiana"           },
                    new SelectListItem(){Value="ME", Text = "Maine"             },
                    new SelectListItem(){Value="MD", Text = "Maryland"          },
                    new SelectListItem(){Value="MA", Text = "Massachusetts"     },
                    new SelectListItem(){Value="MI", Text = "Michigan"          },
                    new SelectListItem(){Value="NH", Text = "New Hampshire"     },
                    new SelectListItem(){Value="NJ", Text = "New Jersey"        },
                    new SelectListItem(){Value="NY", Text = "New York"          },
                    new SelectListItem(){Value="NC", Text = "North Carolina"    },
                    new SelectListItem(){Value="OH", Text = "Ohio"              },
                    new SelectListItem(){Value="PA", Text = "Pennsylvania"      },
                    new SelectListItem(){Value="RI", Text = "Rhode Island"      },
                    new SelectListItem(){Value="SC", Text = "South Carolina"    },
                    new SelectListItem(){Value="VT", Text = "Vermont"           },
                    new SelectListItem(){Value="VA", Text = "Virginia"          },
                    new SelectListItem(){Value="WV", Text = "West Virginia"     },
                };

            }
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AutocompliteSimple()
        {
            return View();
        }

        public ActionResult AutocompliteMulti()
        {
            AutocompliteMultiModel model = new AutocompliteMultiModel();
            model.E9SelectListItems = _ListItems.Select(l => new SelectListItem()
            {
                Text = l.Text,
                Value = l.Value
            }).ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult AutocompliteMulti(AutocompliteMultiModel model)
        {

            model.E9SelectListItems = _ListItems.Select(l => new SelectListItem()
            {
                Text = l.Text,
                Value = l.Value,
                Selected = model.E9.Contains(l.Value)
            }).ToList();


            if (model.AjaxSelect != null)
            {
                //model.AjaxSelected 
                ViewBag.AjaxSelected = string.Join(",", _List.Where(l => model.AjaxSelect.Split(',').ToList().Contains(l.Key.ToString())).Select(l => l.Value));

            }
            if (model.E9 != null)
            {
                //model.E9Selected 
                ViewBag.E9Selected = string.Join(",", _ListItems.Where(l => model.E9.Contains(l.Value)).Select(l => l.Text));
            }
            return PartialView("_MultiSelectDropdown", model);
        }

        /// <summary>
        /// This controller action returns json containing actors searched for via a search term.
        /// </summary>
        /// <param name="searchTerm">a string searchterm to search by names</param>
        /// <returns>list of classes as json</returns>
        public JsonResult SearchClasses(string searchTerm)
        {
            var result = _List.Select(a => new { id = a.Key, text = a.Value }).Where(a => a.text.Contains(searchTerm)).Take(10);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// This controller action returns json object by id.
        /// </summary>
        /// <param name="searchTerm">id</param>
        /// <returns>Object of class as json</returns>
        public JsonResult GetClass(int id)
        {
            var result = _List.Select(a => new { id = a.Key, text = a.Value }).Where(a => a.id == id).FirstOrDefault();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ErrorMessageDisplay()
        {
            EMDEmployee model = new EMDEmployee();
            return View(model);
        }

        [HttpPost]
        public ActionResult ErrorMessageDisplay(EMDEmployee model)
        {
            if (ModelState.IsValid)
            {

            }

            return View(model);
        }
    }
}
