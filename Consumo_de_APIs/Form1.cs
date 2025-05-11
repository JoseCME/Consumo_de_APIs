using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Consumo_de_APIs
{
    public partial class Form1 : Form
    {
        private readonly HttpClient client = new HttpClient();
        private const string GoogleMapsApiKey = "";
        private const string WeatherApiKey = "";
        private JObject resultados;
        string rutaImagen = Path.Combine(Application.StartupPath, "Resources", "inicio.png");
        public Form1()
        {
            InitializeComponent();
            if (Image.FromFile(rutaImagen) != null)
            {
                pictureBoxMapa.Image = Image.FromFile(rutaImagen);
            }
            else
            {
                MessageBox.Show("El recurso 'inicio' no está disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtLugar_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnConsultar_Click(object sender, EventArgs e)
        {
            string lugar = txtLugar.Text.Trim();
            if (string.IsNullOrEmpty(lugar))
            {
                MessageBox.Show("Por favor, ingrese un lugar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Inicializar el objeto de resultados
                resultados = new JObject();

                // Paso 1: Obtener coordenadas con Google Maps Geocoding API
                string googleUrl = $"https://maps.googleapis.com/maps/api/geocode/json?address={Uri.EscapeDataString(lugar)}&key={GoogleMapsApiKey}";
                var googleResponse = await client.GetStringAsync(googleUrl);
                JObject googleData = JObject.Parse(googleResponse);

                if (googleData["status"].ToString() != "OK")
                {
                    MessageBox.Show("No se pudo encontrar el lugar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var result = googleData["results"][0];
                string nombreLugar = result["formatted_address"].ToString();
                double latitud = (double)result["geometry"]["location"]["lat"];
                double longitud = (double)result["geometry"]["location"]["lng"];

                // Mostrar nombre y coordenadas
                lblNombreLugar.Text = $"Lugar: {nombreLugar}";
                lblCoordenadas.Text = $"Coordenadas: {latitud}, {longitud}";

                // Agregar datos al objeto de resultados
                resultados["lugar"] = nombreLugar;
                resultados["latitud"] = latitud;
                resultados["longitud"] = longitud;

                // Paso 2: Obtener el mapa estático con Google Maps Static API
                string mapUrl = $"https://maps.googleapis.com/maps/api/staticmap?center={latitud},{longitud}&zoom=12&size=400x300&key={GoogleMapsApiKey}";
                pictureBoxMapa.Load(mapUrl);

                // Agregar URL del mapa al objeto de resultados
                resultados["mapa_url"] = mapUrl;

                // Paso 3: Obtener clima con OpenWeatherMap API
                string weatherUrl = $"https://api.openweathermap.org/data/2.5/weather?lat={latitud}&lon={longitud}&appid={WeatherApiKey}&units=metric";
                var weatherResponse = await client.GetStringAsync(weatherUrl);
                JObject weatherData = JObject.Parse(weatherResponse);

                string descripcion = weatherData["weather"][0]["description"].ToString();
                double temperatura = (double)weatherData["main"]["temp"];
                double humedad = (double)weatherData["main"]["humidity"];

                // Mostrar datos del clima
                lblClima.Text = $"Clima: {descripcion}, Temperatura: {temperatura}°C, Humedad: {humedad}%";

                // Agregar datos del clima al objeto de resultados
                resultados["clima"] = new JObject
                {
                    ["descripcion"] = descripcion,
                    ["temperatura"] = temperatura,
                    ["humedad"] = humedad
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                resultados = null; // Limpiar resultados en caso de error
            }
        }

        private void lblClima_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtLugar.Text = "";
            lblNombreLugar.Text = "";
            lblCoordenadas.Text = "";
            lblClima.Text = "";
            pictureBoxMapa.Image = Image.FromFile(rutaImagen);
            resultados = null;
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (resultados == null)
            {
                MessageBox.Show("No hay resultados para guardar. Realice una consulta primero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Serializar los resultados a JSON
                string jsonResult = JsonConvert.SerializeObject(resultados, Formatting.Indented);
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"resultados_{DateTime.Now:yyyyMMdd_HHmmss}.json");
                File.WriteAllText(filePath, jsonResult);

                MessageBox.Show($"Resultados guardados en: {filePath}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
