var txtBatteryStatus = document.getElementById("txtBattery");
var txtMotors = document.getElementById("txtMotorsstate");

function initDisplayer() {
    setInterval(GetBatteryStatus, 1000);
    setInterval(GetMotorsState, 1000);
}

function GetBatteryStatus() {
    $.ajax({
        type: "GET",
        /*.net Core may require authentication token, the one below worked for chrome. Not needed in this version of code.*/
        // headers: { "RequestVerificationToken": $('input[name="__RequestVerificationToken"]').val() },
        url: "/Caller?handler=BatteryStatus",
        dataType: "json",

        success: function(msg) {
            // console.info("battery status: " + msg);
            txtBatteryStatus.innerHTML = msg;
        },
        failure: function(response) {
            // console.log("failure: could not get battery status, response: " + response);
        },
        error: function(response) {
            // console.error("error: could not get battery status, response: " + response);
        }
    });
}

function GetMotorsState() {
    $.ajax({
        type: "GET",

        /*.net Core may require authentication token, the one below worked for chrome. Not needed in this version of code.*/
        // headers: { "RequestVerificationToken": $('input[name="__RequestVerificationToken"]').val() }, 

        url: "/Caller?handler=MotorsState",
        dataType: "json",
        success: function(msg) {
            // console.info("Motors state: " + msg);
            if (msg == "True") {
                txtMotors.innerHTML = "ON";
            } else {
                txtMotors.innerHTML = "OFF";
            }
        },
        failure: function(response) {
            // console.log("failure: could not get motors state, response: " + response);
        },
        error: function(response) {
            // console.error("error: could not get motors state, response: " + response);
        }
    });
}