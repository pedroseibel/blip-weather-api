# WeatherAPI

## Descrição
Este é um microserviço RESTful que fornece informações de previsão do tempo para cidades específicas. Ele utiliza a API externa `HG Weather` para obter os dados necessários.

## Endpoints

### `GET /api/WeatherForecast/{cidade}`
Retorna informações de previsão do tempo para a cidade especificada.

## Configuração
Adicione a chave da API no arquivo `appsettings.json`:
```json
{
  "WeatherAPI": {
    "ApiKey": "SUA_CHAVE_DE_API"
  }
}