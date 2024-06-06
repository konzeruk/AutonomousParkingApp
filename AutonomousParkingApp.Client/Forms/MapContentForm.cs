using AutonomousParkingApp.Client.Forms.Contracts;
using AutonomousParkingApp.Client.Forms.Helpers.Constants;
using AutonomousParkingApp.Client.Models.DTO;
using AutonomousParkingApp.Client.Services;
using AutonomousParkingApp.Client.Services.Contracts;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutonomousParkingApp.Client.Forms
{
    public partial class MapContentForm : Form, IMainContentForm
    {
        private readonly IStorageService _storageService;
        private readonly IAuthService _authService;

        private ICollection<ParkingDto> _parkings;

        private Guid? userId;

        public MapContentForm()
        {
            InitializeComponent();

            _storageService = new StorageService();
            _authService = new AuthService();

            _parkings = Task.Run(async () => await _storageService.GetAllParkingAsync()).Result;
        }

        public async void InstanceUser(UserDto user)
        {
            userId = await _authService.GetUserIdByLoginAsync(user.Login);
        }

        private void gMapControl_Load(object sender, EventArgs e)
        {
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            gMapControl.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            gMapControl.MinZoom = MapConstants.MinZoom;
            gMapControl.MaxZoom = MapConstants.MaxZoom;
            gMapControl.Zoom = MapConstants.Zoom;
            gMapControl.Position = new GMap.NET.PointLatLng(MapConstants.XCenterMap, MapConstants.YCenterMap);
            gMapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            gMapControl.CanDragMap = true;
            gMapControl.DragButton = MouseButtons.Left;
            gMapControl.ShowCenter = false;
            gMapControl.ShowTileGridLines = false;

            UpdateOverlays();
        }

        private void UpdateOverlays()
        {
            if (gMapControl.Overlays.Count > 0)
                gMapControl.Overlays.Clear();
            
            gMapControl.Overlays.Add(GetOverlayMarkers());
            gMapControl.Update();
        }

        private GMapOverlay GetOverlayMarkers()
        {
            GMapOverlay gMapMarkers = new GMapOverlay("parking");

            var mapMarkers = GetMarkerParking();

            foreach (var mapMarker in mapMarkers)
                gMapMarkers.Markers.Add(mapMarker);

            return gMapMarkers;
        }

        private ICollection<GMarkerGoogle> GetMarkerParking()
        {
            var mapMarkers = new List<GMarkerGoogle>();
            foreach(var parking in _parkings)
            {
                var mapMarker = new GMarkerGoogle(new GMap.NET.PointLatLng(parking.XCoord, parking.YCoord), GMarkerGoogleType.red);
                mapMarker.ToolTip = new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(mapMarker);

                mapMarker.Tag = parking.ParkingId;
                mapMarker.ToolTipText = $"Адрес парковки: {parking.Address}\n" +
                    $"Количество свободных мест: {parking.NumFreeSpaces}\n" +
                    $"Цена за час: {parking.Price} ₽";

                mapMarker.ToolTipMode = MarkerTooltipMode.OnMouseOver;

                mapMarkers.Add(mapMarker);
            }
           
            return mapMarkers;
        }

        private void gMapControl_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            var parkingId = (Guid)item.Tag;

            var selectTimeReservationForm = new SelectTimeReservationForm();

            selectTimeReservationForm.ShowDialog();

            var checkItTime = selectTimeReservationForm.checkInTime;

            if (!checkItTime.HasValue)
                return;

            CreateReservation(parkingId, checkItTime.Value);

            MessageBox.Show("Вы забронировали место");
        }

        private async void CreateReservation(Guid parkingId, DateTime checkItTime)
        {
            var reservation = new ReservationDto
            {
                ParkingId = parkingId,
                UserId = userId.Value,
                CheckInTime = checkItTime
            };

            await _storageService.AddReservationAsync(reservation);


            _parkings.Clear();
            
            _parkings = await _storageService.GetAllParkingAsync();

            UpdateOverlays();
        }

        public void ChangeEnabledElementControl()
        { 
        }

        public bool IsEnabledElementControl()
        {
            throw null;
        }
    }
}
