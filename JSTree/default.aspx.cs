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

            cat.Add(new Category { text = "Parent 1", children = true, InternalId = 1, ParentId = null, state = "closed", id = "specialChildSubTree" });

            cat.Add(new Category { text = "Parent 2", children = true, InternalId = 2, ParentId = null, state = "closed", id = "specialChildSubTree" });

            cat.Add(new Category { text = "Parent 3", children = true, InternalId = 3, ParentId = null, state = "closed", id = "specialChildSubTree" });


            cat.Add(new Category { text = "Child 1 of parent 1", children = true, InternalId = 4, ParentId = 1, state = "closed" });
            cat.Add(new Category { text = "Child 2 of parent 1", children = true, InternalId = 5, ParentId = 1, state = "closed" });



            cat.Add(new Category { text = "Child 1 of parent 2", children = true, InternalId = 6, ParentId = 1, state = "closed" });
            cat.Add(new Category { text = "Child 2 of parent 2", children = true, InternalId = 7, ParentId = 1, state = "closed" });


            if(parentid == null)
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
        public int InternalId {set; get;}
        public string Name {set; get;}
        public bool children {set; get;}
        public int ? ParentId {set;get;}
        public string state {set;get;}
        public string text {set; get;}
        public string id { set; get; }
    }

    //public class category
    //{

    //}
}