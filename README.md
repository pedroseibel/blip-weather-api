# WeatherAPI

## Descrição
O **WeatherAPI** é um microserviço RESTful desenvolvido em .NET, que fornece informações de previsão do tempo para cidades específicas. Ele integra-se à API externa `HG Weather` para obter dados meteorológicos em tempo real, facilitando a obtenção de informações climáticas precisas para diferentes localidades.

## URL do Deploy
O serviço está implantado no Azure e pode ser acessado através da seguinte URL:

[https://blip-weather-api-abg8f7hfhnamgvgg.brazilsouth-01.azurewebsites.net/api/v1/WeatherForecast/](https://blip-weather-api-abg8f7hfhnamgvgg.brazilsouth-01.azurewebsites.net/api/v1/WeatherForecast/)

## Endpoints

### `GET /api/v1/WeatherForecast/{cidade}`
Retorna informações de previsão do tempo para a cidade especificada.

- **Parâmetros:**
  - `cidade`: Nome da cidade para a qual deseja obter a previsão do tempo.
  
- **Exemplo de Requisição:**

GET /api/v1/WeatherForecast/London

- **Exemplo de Resposta:**

```
{
	"by": "city_name",
	"valid_key": true,
	"results": {
		"temp": 16,
		"date": "20/08/2024",
		"time": "22:02",
		"condition_code": "28",
		"description": "Tempo nublado",
		"currently": "noite",
		"cid": "",
		"city": "Canoas, RS",
		"img_id": "28n",
		"humidity": 91,
		"cloudiness": 75.0,
		"rain": 0.0,
		"wind_speedy": "8.23 km/h",
		"wind_direction": 100,
		"wind_cardinal": "L",
		"sunrise": "06:52 am",
		"sunset": "06:03 pm",
		"moon_phase": "full",
		"condition_slug": "cloudly_night",
		"city_name": "Canoas",
		"timezone": "-03:00",
		"forecast": [
			{
				"date": "20/08",
				"weekday": "Ter",
				"max": 18,
				"min": 16,
				"humidity": 86,
				"cloudiness": 100.0,
				"rain": 0.53,
				"rain_probability": 63,
				"wind_speedy": "6.25 km/h",
				"sunrise": "06:52 am",
				"sunset": "06:03 pm",
				"moon_phase": "full",
				"description": "Chuvas esparsas",
				"condition": "rain"
			},
}
```


 ## Requisitos
- .NET 8.0 SDK
- Uma chave de API válida da HG Weather API.
