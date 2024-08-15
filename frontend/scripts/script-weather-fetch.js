document.addEventListener("DOMContentLoaded", function () {
    fetch('/api/weather')
        .then(response => response.json())
        .then(data => {
            document.getElementById('weather-info').innerText = `Temperature: ${data.temperature}°C`;
        })
        .catch(error => console.error('Error fetching weather data:', error));
});
