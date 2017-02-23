using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;



using System.Web.Services;
using System.Web.Script.Services;
namespace JSTree
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        //[ScriptMethod(UseHttpGet = true)]
        public static IEnumerable<Category> GetCategories(string parentid)
        {

            //creating the data
            //This should  be fetched from DB
            List<Category> cat = new List<Category>();

            cat.Add(new Category { text = "Parent 1", children = true,  ParentId = null, state = "closed", id = 1 });

            cat.Add(new Category { text = "Parent 2", children = true,  ParentId = null, state = "closed", id = 2 });

            cat.Add(new Category { text = "Parent 3", children = true,  ParentId = null, state = "closed", id = 3 });


            cat.Add(new Category { text = "Child 1 of parent 1", children = true,  ParentId = 1, state = "closed", id= 4});
            cat.Add(new Category { text = "Child 2 of parent 1", children = true,  ParentId = 1, state = "closed", id= 5 });



            cat.Add(new Category { text = "Child 1 of parent 2", children = true, InternalId = 6, ParentId = 2, state = "closed", id = 6 });
            cat.Add(new Category { text = "Child 2 of parent 2", children = true, InternalId = 7, ParentId = 2, state = "closed", id = 7 });


            if (parentid == null)
            {
                var output = cat.Where(s => s.ParentId == null);
                return output;
            }
            else
            {
                var output = cat.Where(s => s.ParentId == Convert.ToInt16(parentid));
                return output;
            }



        }
    }

    public class Category
    {
        public int InternalId { set; get; }
        public string Name { set; get; }
        public bool children { set; get; }
        public int? ParentId { set; get; }
        public string state { set; get; }
        public string text { set; get; }
        public int id { set; get; }

        protected internal Category() { }
    }

    //public class category
    //{

    //}
}
