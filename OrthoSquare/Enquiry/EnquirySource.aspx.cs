using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrthoSquare.BAL_Classes;
using System.Data;
using OrthoSquare.Utility;

namespace OrthoSquare.Enquiry
{
    public partial class EnquirySource : System.Web.UI.Page
    {
        BAL_EnquirySource objES = new BAL_EnquirySource();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int _isInserted = -1;
            _isInserted = objES.AddEnqirySource(txtname.Text);

            txtname.Text = "";
        }
    }
}