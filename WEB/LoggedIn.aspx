<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoggedIn.aspx.cs" Inherits="WEB.LoggedIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
         <!--Script references. -->
        <!--Reference the jQuery library. -->
        <script src="Scripts/jquery-1.8.2.min.js"></script>      
        <script src="Scripts/jquery-1.8.2.min.js"></script>

        <!--Reference the signalR library-->       
        <script src="Scripts/jquery.signalR-2.1.1.min.js"></script>
        <script src="http://localhost:8089/signalr/hubs"></script>
         <style type="text/css">
          @import url(http://fonts.googleapis.com/css?family=Lato);

* {
  margin:0;
  padding:0;
}


html {
  font:12pt Lato, sans-serif;
  min-height:100%;
  background-image:linear-gradient(45deg,#3498db,#2ecc71);
}

.notifications {
  display:block;
  position:relative;
  margin:100px auto;
  width:80px;
  height:80px;
  background-color:white;
  border-radius:50%;
}

.notifications .toggle {
  display:block;
  position:relative;
  width:100%;
  height:100%;
}


.notifications .toggle:before,
.notifications .toggle:after {
  content:'.';
  display:block;
  position:relative;
  left:35px;
  width:10px;
  background-color:#bdc3c7;
  color:transparent;
  border-radius:5px;
}

.notifications .toggle:before {
  top:15px;
  height:30px;
}

.notifications .toggle:after {
  top:25px;
  height:10px;
}

.notifications .messages {
  display:block;
  position:absolute;
  top:100px;
  left:-80px;
  width:240px;
  max-height:240px;
}

.notifications .messages:before {
  content:'.';
  display:block;
  position:absolute;
  margin-left:-10px;
  left:50%;
  top:-18px;
  width:0;
  height:0;
  color:transparent;
  border:10px solid black;
  border-color:transparent transparent white;
}

.notifications .messages .message {
  display:block;
  position:relative;
  padding:10px;
  background-color:white;
  color:black;
  text-decoration:none;
}

.notifications .newmessage {
  display:block;
  position:absolute;
  top:100px;
  left:-80px;
  width:240px;
  max-height:240px;
  padding:10px;
  background-color:white;
  color:black;
  text-decoration:none;
}

          .notifications .newmessage:before {
              content: '.';
              display: block;
              position: absolute;
              margin-left: -10px;
              left: 50%;
              top: -18px;
              width: 0;
              height: 0;
              color: transparent;
              border: 10px solid black;
              border-color: transparent transparent white;
          }

.notifications .messages .message + .message {
  border-top:1px solid #e0e0e0;
}

.notifications .bubble {
 position:absolute;    /* This breaks the div from the normal HTML document. */
    top: 6px;
    right:6px;
    padding:1px 2px 1px 2px;
    background-color:red; /* you could use a background image if you'd like as well */
    color:white;
    font-weight:bold;
    font-size:0.70em;
    border-radius:30px;
    box-shadow:1px 1px 1px gray;
    height: 18px;
    width: 14px;
    text-align:center;
             }

          </style>   
        <script type="text/javascript">
            $(function () {
                var id = parseInt(sessionStorage.id);
                var group = sessionStorage.getItem("group");
                document.getElementById("container2").innerHTML = "'" + id + "'";
                document.getElementById("container3").innerHTML = "'" + group + "'";
                $.connection.hub.url = "http://localhost:8089/signalr";
                // Declare a variable to refer to the hub
                var proxy = $.connection.myHub;
                // Register Client functions
                proxy.client.receiveAlert = function (messge) {
                    AddMessage(messge);
                };
                // Start the Hub
                $.connection.hub.start().done(function () {
                    proxy.server.connect(id, group);
                });
                $(function () {
                    $('.notifications .newmessage').hide();
                    $(".notifications .messages").hide();
                    $(".notifications").click(function () {
                        if ($(this).children(".messages").children().length > 0) {
                            $('.newmessage').hide();
                            $(this).children(".messages").not('.newmessage').fadeToggle(300);
                        }
                    });
                });
            });

            var n = 0;
            function AddMessage(messagetext) {
                $(".newmessage").empty();
                $(".newmessage").html(messagetext);
                n = n + 1;
                $('.bubble').html(n);
                $('.messages').append('<a href="#" class="message">' + messagetext + '</a>');
                $('.messages').hide();
                $("div").children(".newmessage").fadeIn(300);
                $(".newmessage").delay(3200).fadeOut(300);
            }
</script>
</head>
<body style="height: 485px">
    <div style="text-align:center"> 
        Welcome user
       <div class="notificationBalloon" id="container2" > </div>
        of group
        <div class="notificationBallon" id="container3" > </div>
        </div>
    <br />
        <div class="notifications">
        <div class="newmessage" ></div>
  <div class="toggle" ><div class="bubble">0</div> </div>
        
  <div class="messages" id="messages">  </div>
</div>
 
    </body>
</html>