# Guider.API.Pages
## CRUD операции в API ASP.NET с  объектами универсальной  коллекции в MongoDb, так что  тип ключей был по умолчанию, а значениеми были бы json объекты любой сложности .

1. Установлен пакет MongoDB.Driver
2. Создана модель данных
3. Настроен MongoDB контекст
4. Реализован репозиторий для CRUD операций
5. Предварительная настройка конфигурации в appsettings.json
6. Регистрация сервисов в Program.cs
7. Создан контроллер для CRUD операций

   ## Примеры запросов
GET /api/documents
Возвращает все документы.

GET /api/documents/{id}
Возвращает документ по идентификатору.

POST /api/documents
Тело запроса:

json
Copy
Edit
{
  "title": "Sample Page",
  "content": "This is a test content",
  "meta": { "author": "John Doe", "tags": ["test", "sample"] }
}
PUT /api/documents/{id}
Обновление данных документа.

DELETE /api/documents/{id}
Удаляет документ по идентификатору.
