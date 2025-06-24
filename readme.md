✅ Тестовое задание: API «TODO» на ASP.NET Core
🎯 Цель:
Создать REST API для управления списком задач (TODO) на ASP.NET Core с использованием Entity Framework Core и SQLite или InMemory в качестве БД.

📌 Требования к функционалу:
📄 Модель TodoItem
Id – Guid

Title – string, обязательное

IsCompleted – bool

CreatedAt – DateTime

🔧 CRUD Endpoints:
Метод  URL  Описание
GET  /api/todos  Получить список всех задач
GET  /api/todos/{id}  Получить задачу по ID
POST  /api/todos  Создать новую задачу
PUT  /api/todos/{id}  Обновить существующую задачу
DELETE  /api/todos/{id}  Удалить задачу

💡 Бонусные (опциональные) требования:
Валидация входных данных (через [Required], [StringLength] и т.д.)

Логгирование действий

Использование DTO и AutoMapper

Обработка ошибок (middleware или ProblemDetails)

Написать Unit-тест хотя бы для одного метода