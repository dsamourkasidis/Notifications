<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WEB.Login" %>

<!DOCTYPE html>

<html> 
<head>
    <title>Login Page</title>
    <script src="/Scripts/jquery-1.8.2.min.js" ></script>

    <script type="text/javascript">
        $(function () {
            $("#button1").click(function () {
                var group = $("#text2").val();
                var id = $("#text1").val();
                if (id > 0) {
                    if (group.length > 0) {
                        sessionStorage.setItem("id", id);
                        sessionStorage.setItem("group", group);
                        window.location.href = 'LoggedIn.aspx' + "?previousPage=" + document.URL;
                    }
                    else {
                        alert("Please enter group name");
                    }
                }
                else {
                    alert("Please enter name");
                }
            });
        });

        </script>
     

</head>
<body>
   <div style="text-align:center">
    <p>User ID:
        <input id="text1" type="text" size="3"/>
    </p>
    <p>Group Name:
        <input id="text2" type="text" size="8"/>
    </p>
    <input id="button1" type="button" value="Login"  />
    </div>
       <br />
        <br />
     <div class="notificationBalloon" id="container" >     </div>
</body>
</html>