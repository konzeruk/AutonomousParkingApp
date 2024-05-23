using AutonomousParkingApp.Client.Forms.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutonomousParkingApp.Client.Forms
{
    public partial class MapContentForm : Form
    {
        public MapContentForm()
        {
            InitializeComponent();
        }

        private void gMapControl_Load(object sender, EventArgs e)
        {
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache; //выбор подгрузки карты – онлайн или из ресурсов
            gMapControl.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance; //какой провайдер карт используется (в нашем случае гугл) 
            gMapControl.MinZoom = MapConstants.MinZoom; //минимальный зум
            gMapControl.MaxZoom = MapConstants.MaxZoom; //максимальный зум
            gMapControl.Zoom = MapConstants.Zoom; // какой используется зум при открытии
            gMapControl.Position = new GMap.NET.PointLatLng(MapConstants.XCenterMap, MapConstants.YCenterMap);// точка в центре карты при открытии (центр России)
            gMapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter; // как приближает (просто в центр карты или по положению мыши)
            gMapControl.CanDragMap = true; // перетаскивание карты мышью
            gMapControl.DragButton = MouseButtons.Left; // какой кнопкой осуществляется перетаскивание
            gMapControl.ShowCenter = false; //показывать или скрывать красный крестик в центре
            gMapControl.ShowTileGridLines = false; //показывать или скрывать тайлы
        }
    }
}
