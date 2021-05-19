
<!DOCTYPE html>
<html>
<head>
    <title>Client Satisfaction Form</title>
	<link rel="stylesheet" type="text/css" href="css/style.css">
	<link href="https://fonts.googleapis.com/css?family=Poppins:600&display=swap" rel="stylesheet">
	<script src="https://kit.fontawesome.com/a81368914c.js"></script>
	<meta name="viewport" content="width=device-width, initial-scale=1">
    <script>
</script>
</head>
<body>
    <img class="wave" src="img/wave.jpg">
    <div class="container">
        <div class="img">
            <img src="img/bg.svg">
        </div>
        <div class="satisfaction-content">
            <form action="includes\submit.inc.php" method="POST">
                <img src="img/PSSLogo.png">
                <hr style="height:2px;border-width:1px;color:#6a0d9b;background-color:#6a0d9b"> 
                <h2 class="title">Welcome</h2>
                <h4 class="title">Please rate our services by filling in below</h4>
                <div class="input-div one">
                    <div class="i">
                        <i class="user-name"></i>
                    </div>
                    <div class="div">
                        <h5>Client ID</h5>
                        <input type="text" class="input" name="clientID">
                    </div>
                </div>

                <div class="input-div one">
                    <div class="i">
                        <i class="user-name"></i>
                    </div>
                    <div class="div">
                        <h5>Client/Business Name (Optional)</h5>
                        <input type="text" class="input" name="Name">
                    </div>
                </div>

                <div class="input-div pass">
                    <div class="i">
                        <i class="user-rating"></i>
                    </div>
                    <div class="div">
                        <h5>User rating from 1 - 5</h5>
                        <input type="text" class="input" name="rating">
                    </div>
                </div>
                <a href="#" data-modal-target="#modal">Exit</a>
                <button type="submit" class="btn" name="submit">Submit</button>
            </form>

  <div class="modal" id="modal">
    <div class="modal-header">
      <div class="title">Premier Service Solutions</div>
      <button data-close-button class="close-button">&times;</button>
    </div>
    <div class="modal-body">
      Thank you for filling in the form. An employee will get in contact with you soon to discuss how we can better your experiance going forward.
      <br><br>Feel free to exit this webpage.
    </div>
  </div>
  <div id="overlay"></div>

        </div>
    </div>
    <script type="text/javascript" src="js/main.js"></script>
</body>
</html>