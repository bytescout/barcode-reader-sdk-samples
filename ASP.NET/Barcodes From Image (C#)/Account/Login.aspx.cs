//*******************************************************************
//
// Download evaluation version: https://bytescout.com/download/web-installer
//
// Signup Cloud API free trial: https://secure.bytescout.com/users/sign_up
//
// Copyright © 2017 ByteScout Inc. All rights reserved.
// http://www.bytescout.com
//                                                                   
//*******************************************************************


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Barcodes_From_Image.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        }
    }
}
