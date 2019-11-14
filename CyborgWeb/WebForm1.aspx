<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="CyborgWeb.WebForm1" %>


<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>Cyborg Web App</title>

    <!-- Bootstrap core CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <link rel="stylesheet" href="https://unpkg.com/bootstrap-table@1.15.5/dist/bootstrap-table.min.css">

    <!-- Custom styles for this template -->
    <link href="css/agency.min.css" rel="stylesheet">
    <link href="css/default.css" rel="stylesheet" type="text/css">
    <link href="css/Counter.css" rel="stylesheet" type="text/css">

    <%-- Some cool fonts --%>
    <link href="https://fonts.googleapis.com/css?family=Montserrat:400,700" rel="stylesheet" type="text/css">
    <link href='https://fonts.googleapis.com/css?family=Kaushan+Script' rel='stylesheet' type='text/css'>
    <link href='https://fonts.googleapis.com/css?family=Droid+Serif:400,700,400italic,700italic' rel='stylesheet' type='text/css'>
    <link href='https://fonts.googleapis.com/css?family=Roboto+Slab:400,100,300,700' rel='stylesheet' type='text/css'>

    <!-- Font-awesome Icons -->
    <script src="https://kit.fontawesome.com/ffd2f95330.js" crossorigin="anonymous"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <%--<script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>--%>
    <%--<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>--%>
    <script src="js/Custom'.js" type="text/javascript"></script>
    <script src="js/Counter.js" type="text/javascript"></script>

</head>

<body id="page-top" onload="init()">
    <form id="form1" runat="server">

        <!-- Navigation -->
        <nav class="navbar navbar-expand-lg navbar-dark fixed-top" id="mainNav" style="background-color: #0e0e0e">
            <div class="container">
                <a class="navbar-brand js-scroll-trigger" href="#page-top">The Cyborg</a>
                <button class="navbar-toggler navbar-toggler-right" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
                    <i class="fas fa-bars"></i>
                </button>
                <div class="collapse navbar-collapse" id="navbarResponsive">
                    <ul class="navbar-nav text-uppercase ml-auto">
                        <li class="nav-item">
                            <a class="nav-link js-scroll-trigger" href="#contact">Contact</a>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>

        <!-- Header -->
        <header class="masthead" style="height:1050px">
            <div class="container">
                <div class="intro-text">
                    <div class="intro-lead-in">Welcome To The Cyborg Website</div>
                    <div class="intro-heading text-uppercase">The Cyborg v4.0</div>
                    <%--<a class="btn btn-primary btn-xl text-uppercase js-scroll-trigger" href="#services"></a>--%>
                    <%--<asp:Button runat="server" ID="btnGetData" OnClientClick="" CssClass="btn btn-primary btn-xl text-uppercase" Text="Take test" OnClick="BtnGetData_Click"/>--%>
                </div>
                <div class="container">
                    <br />
                    <%--<div class="row">
                        <div class="col text-center">
                            <h2>Bootstrap 4 counter</h2>
                            <p>counter to count up to a target number</p>
                        </div>
                    </div>--%>
                    <div class="row text-center">
                        <div class="col">
                            <div class="counter">
                                <i class="fa fa-battery fa-2x"></i>
                                <h2 runat="server" id="txtBattery" class="count-title">5</h2>
                                <%--<h2 runat="server" id="txtBattery" class="timer count-title count-number" data-to="100" data-speed="1500">5</h2>--%>
                                <p class="count-text ">Battery Charge</p>
                            </div>
                        </div>
                        <div class="col">
                            <div class="counter">
                                <i class="fa fa-toggle-on fa-2x"></i>
                                <h2 runat="server" id="txtMotorsstate" class="count-title">Hei</h2>
                                <p class="count-text ">Motor On</p>
                            </div>
                        </div>
<%--                        <div class="col">
                            <div class="counter">
                                <i class="fa fa-lightbulb-o fa-2x"></i>
                                <h2 class="count-title" data-to="56" data-speed="1500">15</h2>
                                <p class="count-text ">Number</p>
                            </div>
                        </div>
                        <div class="col">
                            <div class="counter">
                                <i class="fa fa-bug fa-2x"></i>
                                <h2 class="timer count-title count-number" data-to="157" data-speed="1500">20</h2>
                                <p class="count-text ">Bugs</p>
                            </div>
                        </div>--%>
                    </div>
                </div>
                <%--<div class="col-lg-6">
                    <div class="form-group mb-2">
                        <input type="text" readonly class="form-control-plaintext" id="staticEmail2" value="email@example.com">
                        <input type="text" readonly class="form-control-plaintext" id="staticEmail2" value="email@example.com">
                </div>
                </div>
                <div class="col-lg-6">
                    Boo

                </div>--%>
            </div>
        </header>

        <%--<!-- Services -->
        <section class="page-section" id="services">
            <div class="container">
                <div class="row">
                    <div class="col-lg-12 text-center">
                        <h2 class="section-heading text-uppercase">Select Quiz</h2>
                        <!-- dropdown -->
                        <div class="dropdown">
                            <button class="btn btn-lg btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                Chapter
                            </button>
                            <div runat="server" id="dropdownmenu" class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                                <button runat="server" id="dropdown1" onclick="openModal(this)" class="dropdown-item" style="display: none" value="0" data-toggle="modal" data-target="#LectureModal" type="button">1</button>
                                <button runat="server" id="dropdown2" onclick="openModal(this)" class="dropdown-item" style="display: none" value="1" data-toggle="modal" data-target="#LectureModal" type="button">2</button>
                                <button runat="server" id="dropdown3" onclick="openModal(this)" class="dropdown-item" style="display: none" value="2" data-toggle="modal" data-target="#LectureModal" type="button">3</button>
                                <button runat="server" id="dropdown4" onclick="openModal(this)" class="dropdown-item" style="display: none" value="3" data-toggle="modal" data-target="#LectureModal" type="button">4</button>
                                <button runat="server" id="dropdown5" onclick="openModal(this)" class="dropdown-item" style="display: none" value="4" data-toggle="modal" data-target="#LectureModal" type="button">5</button>
                                <button runat="server" id="dropdown6" onclick="openModal(this)" class="dropdown-item" style="display: none" value="5" data-toggle="modal" data-target="#LectureModal" type="button">6</button>
                                <button runat="server" id="dropdown7" onclick="openModal(this)" class="dropdown-item" style="display: none" value="6" data-toggle="modal" data-target="#LectureModal" type="button">7</button>
                                <button runat="server" id="dropdown8" onclick="openModal(this)" class="dropdown-item" style="display: none" value="7" data-toggle="modal" data-target="#LectureModal" type="button">8</button>
                                <button runat="server" id="dropdown9" onclick="openModal(this)" class="dropdown-item" style="display: none" value="8" data-toggle="modal" data-target="#LectureModal" type="button">9</button>
                                <button runat="server" id="dropdown10" onclick="openModal(this)" class="dropdown-item" style="display: none" value="9" data-toggle="modal" data-target="#LectureModal" type="button">10</button>
                                <button runat="server" id="dropdown11" onclick="openModal(this)" class="dropdown-item" style="display: none" value="10" data-toggle="modal" data-target="#LectureModal" type="button">11</button>
                                <button runat="server" id="dropdown12" onclick="openModal(this)" class="dropdown-item" style="display: none" value="11" data-toggle="modal" data-target="#LectureModal" type="button">12</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>--%>

        <%--        <!-- Our Story -->
        <section class="page-section" id="about">
            <div class="container">
                <div class="row">
                    <div class="col-lg-12 text-center">
                        <h2 class="section-heading text-uppercase">The Cyborg Story</h2>
                        <h3 class="section-subheading text-muted">Read about Group 27's story for all phases throughout this project.</h3>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-12">
                        <ul class="timeline">
                            <li>
                                <div class="timeline-image">
                                    <img class="rounded-circle img-fluid" src="img/about/1.jpg" alt="">
                                </div>
                                <div class="timeline-panel">
                                    <div class="timeline-heading">
                                        <h4>August - September 2019</h4>
                                        <h4 class="subheading">Our Humble Beginnings</h4>
                                    </div>
                                    <div class="timeline-body">
                                        <p class="text-muted">It all started as a wish to create an interactive learning experience for our classmates.</p>
                                    </div>
                                </div>
                            </li>
                            <li class="timeline-inverted">
                                <div class="timeline-image">
                                    <img class="rounded-circle img-fluid" src="img/about/Learning.jpg" alt="">
                                </div>
                                <div class="timeline-panel">
                                    <div class="timeline-heading">
                                        <h4>Late September 2019</h4>
                                        <h4 class="subheading">A Project is Born</h4>
                                    </div>
                                    <div class="timeline-body">
                                        <p class="text-muted">We decided we wanted to make some sort of online test, one that was easy to access, entertaining and educational. </p>
                                    </div>
                                </div>
                            </li>
                            <li>
                                <div class="timeline-image">
                                    <img class="rounded-circle img-fluid" src="img/about/koding.jpg" alt="">
                                </div>
                                <div class="timeline-panel">
                                    <div class="timeline-heading">
                                        <h4>Early October 2019</h4>
                                        <h4 class="subheading">Challenges</h4>
                                    </div>
                                    <div class="timeline-body">
                                        <p class="text-muted">The road ahead wasn't clear, but the mind and body was willing and ready.</p>
                                    </div>
                                </div>
                            </li>
                            <li class="timeline-inverted">
                                <div class="timeline-image">
                                    <img class="rounded-circle img-fluid" src="img/about/Testing.jpg" alt="">
                                </div>
                                <div class="timeline-panel">
                                    <div class="timeline-heading">
                                        <h4>October 2019</h4>
                                        <h4 class="subheading">Trying and improving</h4>
                                    </div>
                                    <div class="timeline-body">
                                        <p class="text-muted">We tried out different solutions and settled on those that fit our objective the best.</p>
                                    </div>
                                </div>
                            </li>
                             <li>
                                <div class="timeline-image">
                                    <img class="rounded-circle img-fluid" src="img/about/Logo_1.PNG" alt="">
                                </div>
                                <div class="timeline-panel">
                                    <div class="timeline-heading">
                                        <h4>Late October 2019 </h4>
                                        <h4 class="subheading">Final Touches and a finished product</h4>
                                    </div>
                                    <div class="timeline-body">
                                        <p class="text-muted">Launching our website was a great feeling, with great effort and long nights we pulled through.</p>
                                    </div>
                                </div>
                            </li>
                            <li class="timeline-inverted">
                                <div class="timeline-image">
                                    <h4>What
                  <br>
                                        Is
                  <br>
                                        Next?</h4>
                                </div>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </section>--%>

        <!-- Contact -->
        <section class="page-section" style="height:990px" id="contact">
            <div class="container">
                <div class="row">
                    <div class="col-lg-12 text-center">
                        <h2 class="section-heading text-uppercase">Contact</h2>
                        <h3 class="section-subheading text-muted">Please leave feedback.</h3>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-12">
                        <form id="contactForm" name="sentMessage" novalidate="novalidate">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <input class="form-control" id="name" name="name" type="text" placeholder="Your Name *" required="required" data-validation-required-message="Please enter your name.">
                                        <p class="help-block text-danger"></p>
                                    </div>
                                    <div class="form-group">
                                        <input class="form-control" id="email" name="email" type="email" placeholder="Your Email *" required="required" data-validation-required-message="Please enter your email address.">
                                        <p class="help-block text-danger"></p>
                                    </div>
                                    <div class="form-group">
                                        <input class="form-control" id="phone" name="phone" type="tel" placeholder="Your Phone *" required="required" data-validation-required-message="Please enter your phone number.">
                                        <p class="help-block text-danger"></p>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <textarea class="form-control" id="message" name="message" placeholder="Your Message *" required="required" data-validation-required-message="Please enter a message."></textarea>
                                        <p class="help-block text-danger"></p>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <div class="col-lg-12 text-center">
                                    <div id="success"></div>
                                    <asp:Button runat="server" ID="sendMessageButton" class="btn btn-primary btn-xl text-uppercase" type="submit" Text="Send Message" OnClick="sendMessageButton_Click" />
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </section>

        <!-- Footer -->
        <footer class="footer">
            <div class="container">
                <div class="row align-items-center">
                    <div class="col-md-4">
                        <span class="copyright">Copyright &copy; Casper Nilsen 2019</span>
                    </div>
                    <div class="col-md-4">
                    </div>
                    <div class="col-md-4">
                        <ul class="list-inline quicklinks">
                            <li class="list-inline-item">
                                <a href="https://www.ntnu.edu/privacy">Privacy Policy</a>
                            </li>
                            <li class="list-inline-item">
                                <a href="https://opensource.org/licenses/MIT">Terms of Use</a>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </footer>


        <!-- Bootstrap core JavaScript -->
        <%--<script src="vendor/jquery/jquery.min.js" type="text/javascript"></script>--%>
<%--        <script src="vendor/popper/popper.min.js" type="text/javascript"></script>
        <script src="vendor/bootstrap/js/bootstrap.bundle.min.js" type="text/javascript"></script>--%>

        <!-- Plugin JavaScript -->
        <script src="vendor/jquery-easing/jquery.easing.min.js" type="text/javascript"></script>

        <!-- Contact form JavaScript -->
        <script src="js/jqBootstrapValidation.js" type="text/javascript"></script>
        <script src="js/contact_me.js" type="text/javascript"></script>

        <!-- Custom scripts for this template -->
        <script src="js/agency.min.js" type="text/javascript"></script>

        <script src="https://unpkg.com/bootstrap-table@1.15.5/dist/bootstrap-table.min.js"></script>
    </form>
</body>

</html>
