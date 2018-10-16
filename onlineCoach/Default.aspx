<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="onlineCoach._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1 class="title">Online Coach</h1>
        <img src="Content/runners-635906_960_720.jpg" width="100%"/>
        <h3 class="cntr">Educate today for a healthier tommorow!</h3>
    </div>
     <h2 class="title">Welcome to Online Coach</h2>
        
    
    <div class="row">
       
        <div class="col-md-6">
         <p>Obesity can lead to a lot of diseases such as heart disease, stroke, high blood pressure, diabetes, cancers, breathing problems and many more.</p>
    <iframe width="560" height="315" src="https://www.youtube.com/embed/CodB8Q71Sok" frameborder="0" allowfullscreen></iframe>
            </div>
        <div class="col-md-6">
            <p>While exercising can help with losing weight, it is only half the journey, developing healthy eating habits is the most crucial thing whether you're trying to lose or gain weight.</p>
    <iframe width="560" height="315" src="https://www.youtube.com/embed/WSWPgFkUUeU" frameborder="0" allowfullscreen></iframe>
            </div>
        </div>
    <div class="row">
        <div class="col-md-6">
            <h2 class="title">Free services</h2>
            <p class="cntr"><img src="Content/SignUp.png" width="57%"/></p>
            <p>
               Our services such as accounts, exercise and nutritional advice are completely free so make your free account today and track your weight gain/loss journey and recieve great advice from our certified trainers
            </p>
            <p>
               <a class="btn btn-default" href="SignUp.aspx">Create account &raquo;</a>
            </p>
        </div>
        <div class="col-md-6">
            <h2 class="title">Nutrition lecture</h2>
            <p class="cntr"><img src="Content/businessman-607831_960_720.png" width="50%"/></p>
            <p>
               We provide a 1 hour lecture about proper nutrition and exercise for people of all ages, if you are looking to teach the people around you about living a healthier lifestyle then you've come to the right place! We provide these lectures at a very reasonable price so book now
            </p>
            <p>
                <a class="btn btn-default" href="Booking.aspx">Book now &raquo;</a>
            </p>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
         
            </div>
        <div class="col-md-4">
        
            </div>
        <div class="col-md-4">
       
            </div>
    </div>

</asp:Content>
