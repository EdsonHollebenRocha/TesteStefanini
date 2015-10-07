using Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class CustomerListPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillDdlCities();
                fillDdlRegions();

                ddlLastPurchase1.DataSource = Client.getLastPurchasesMinus();
                ddlLastPurchase1.DataTextField = "LastPurchase";
                ddlLastPurchase1.DataValueField = "LastPurchase";
                ddlLastPurchase1.DataBind();
                ddlLastPurchase1.Items.Insert(0, string.Empty);

                ddlLastPurchase2.DataSource = Client.getLastPurchasesPlus();
                ddlLastPurchase2.DataTextField = "LastPurchase";
                ddlLastPurchase2.DataValueField = "LastPurchase";
                ddlLastPurchase2.DataBind();
                ddlLastPurchase2.Items.Insert(0, string.Empty);

                ddlClassification.DataSource = Client.getClassifications();
                ddlClassification.DataTextField = "ClassificationName";
                ddlClassification.DataValueField = "ClassificationId";
                ddlClassification.DataBind();
                ddlClassification.Items.Insert(0, string.Empty);

            }
        }

        private void fillDdlRegions()
        {
            ddlRegion.DataSource = Client.getRegions();
            ddlRegion.DataTextField = "RegionName";
            ddlRegion.DataValueField = "RegionId";
            ddlRegion.DataBind();
            ddlRegion.Items.Insert(0, string.Empty);
        }

        private void fillDdlCities()
        {
            ddlCity.DataSource = Client.getCities();
            ddlCity.DataTextField = "CityName";
            ddlCity.DataValueField = "CityId";
            ddlCity.DataBind();
            ddlCity.Items.Insert(0, string.Empty);
        }

        

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            fillGrvClients();
        }

        private void fillGrvClients()
        {
            User user = (User)Session["User"];
            DataTable table = null;
            string filters = string.Empty;
            filters = makeFilter(" AND C1.Name like ", filters, "%" + txtName.Text + "%");
            filters = makeFilter(" AND C1.Gender = ", filters, ddlGender.SelectedValue);
            filters = makeFilter(" AND C1.CityId = ", filters, ddlCity.SelectedValue);
            filters = makeFilter(" AND C1.RegionId = ", filters, ddlRegion.SelectedValue);
            filters = makeFilterRange(" AND c1.LastPurchase between ", filters, ddlLastPurchase1.SelectedValue, ddlLastPurchase2.SelectedValue);
            filters = makeFilter(" AND C1.ClassificationId = ", filters, ddlClassification.SelectedValue);

            if (user.Id.ToUpper() == "682CA6CD-6502-4AE3-BF45-5153BEB9C0A0")
            {
                table = Client.getClients(filters);
            }
            else
            {
                table = Client.getClients(user.Id, filters);
            }
            grvClients.DataSource = table;
            grvClients.DataBind();
        }

        private string makeFilter(string dbFilter, string filter,string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                filter += dbFilter + DB.Quote(value);
            }

            return filter;
        }

        private string makeFilterRange(string dbFilter, string filter, string value1, string value2)
        {
            if (!string.IsNullOrEmpty(value1) && !string.IsNullOrEmpty(value1))
            {
                DateTime date1;
                DateTime date2;
                if (DateTime.TryParse(value1, out date1) && DateTime.TryParse(value2, out date2))
                {
                    value1 = date1.ToString("MM/dd/yyyy");
                    value2 = date2.ToString("MM/dd/yyyy");
                }
                filter += dbFilter + DB.Quote(value1) + "and" + DB.Quote(value2);
            }

            return filter;
        }
        
    }
}