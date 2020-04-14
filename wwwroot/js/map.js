   /**
    * Setup all visualization elements when the page is loaded.
   */
function initMap() {
    // Create the main viewer.
    var viewer = new ROS2D.Viewer({
        divID : 'map',
        width : 700,
        height : 700
        });
        
    var gridClient = new NAV2D.OccupancyGridClientNav({
        ros : ros,
        rootObject : viewer.scene,
        viewer : viewer,
        serverName : '/move_base'
    });
    
    // // Setup the map client.
    // var gridClient = new ROS2D.OccupancyGridClient({
    // ros : ros,
    // topic : "/map",
    // rootObject : viewer.scene
    // });

    // // Scale the canvas to fit to the map
    // gridClient.on('change', function(){
    // viewer.scaleToDimensions(gridClient.currentGrid.width, gridClient.currentGrid.height);
    // });
}