<%@ Page Title="" Language="C#" MasterPageFile="~/OrthoSquare.Master" AutoEventWireup="true" CodeBehind="feedbackDetails.aspx.cs" Inherits="OrthoSquare.feedback.feedbackDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/normalize/5.0.0/normalize.min.css">

  <link rel='stylesheet' href='https://afeld.github.io/emoji-css/emoji.css'>

      <link rel="stylesheet" href="css/style.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    
    
    
    <div class="page-content" id="Add"  runat="server">
        <!-- BEGIN PAGE HEADER-->


        <div class="page-bar">
            <ul class="page-breadcrumb">
                <li>
                    <i class="icon-home"></i>
                    <a href="index-2.html">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <span>Pack</span>
                </li>
            </ul>

        </div>
        <!-- END PAGE HEADER-->

        <div class="row">
            <div class="col-md-12">
                <div style="margin-bottom: 5px;">
                    <asp:Label ID="lblMessage" class="panel-title" runat="server" Text="" Font-Size="Medium"></asp:Label>
                </div>
                <!-- BEGIN SAMPLE FORM PORTLET-->
                <div class="portlet light ">
                    <div class="portlet-title">
                        <div class="caption font-red-sunglo">
                            <i class="icon-settings font-red-sunglo"></i>
                            <span class="caption-subject bold uppercase">Pack</span>
                        </div>
                       <%-- <div class="actions">
                            <div class="btn-group">
                                <a class="btn btn-sm green dropdown-toggle" href="javascript:;" data-toggle="dropdown">Actions
                                                <i class="fa fa-angle-down"></i>
                                </a>
                                <ul class="dropdown-menu pull-right">
                                    <li>
                                        <a href="javascript:;">
                                            <i class="fa fa-pencil"></i>Edit </a>
                                    </li>
                                    <li>
                                        <a href="javascript:;">
                                            <i class="fa fa-trash-o"></i>Delete </a>
                                    </li>
                                    <li>
                                        <a href="javascript:;">
                                            <i class="fa fa-ban"></i>Ban </a>
                                    </li>
                                    <li class="divider"></li>
                                    <li>
                                        <a href="javascript:;">Make admin </a>
                                    </li>
                                </ul>
                            </div>
                        </div>--%>
                    </div>
                    <div class="row">

                <Div class="rating-wrapper">        
     <label class="rating-label">How helpful was this?
    <div class="ratingItemList">
     <!-- <input class="rating rating-1" id="rating-1-2" type="radio" value="1" name="rating"/>
      <label class="rating rating-1" for="rating-1-2"><i class="em em-angry"></i></label>-->
      <input class="rating rating-2" id="rating-2-2" type="radio" value="2" name="rating"/>


      <label class="rating rating-2" for="rating-2-2"><i class="em em-disappointed"></i><h6>Unsatisfactory</h6></label>
      <input class="rating rating-3" id="rating-3-2" type="radio" value="3" name="rating"/>
      <label class="rating rating-3" for="rating-3-2"><i class="em em-expressionless"></i><h6>Satisfactory </h6></label>
      <input class="rating rating-4" id="rating-4-2" type="radio" value="4" name="rating"/>
      <label class="rating rating-4" for="rating-4-2"><i class="em em-grinning"></i><h6>Very Satisfactory </h6></label>
     <!-- <input class="rating rating-5" id="rating-5-2" type="radio" value="5" name="rating"/>
      <label class="rating rating-5" for="rating-5-2"><i class="em em-heart_eyes"></i></label>-->
    </div>
  </label>
  <div class="feedback">
    <textarea placeholder="What can we do to improve?"></textarea>
    
    <button class="submit">Send Your Feedback</button>
  </div>

 </div>
                        
                        <!-- END CONTENT BODY -->
                    </div>
                    
                </div>
            </div>
            <!-- END CONTENT BODY -->
        </div>


    </div>
    
    
    
    
    
    

     <script src='https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js'></script>

  

    <script  src="js/index.js"></script>
</asp:Content>
