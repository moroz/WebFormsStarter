using System;
using MyApp.Models;

namespace MyApp
{
    public class BasePage : System.Web.UI.Page
    {
        protected readonly AppDbContext _db = new AppDbContext();

        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
            _db.Dispose();
        }
    }
}