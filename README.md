# Разработка автоматизированной информационной системы “Учёта и контроля инвентаризации” (C#)

![image](https://github.com/MEAWWWS/Accounting-and-inventory-control/assets/114382568/f22259c8-f7b6-45f0-8024-978bfede6a65)
![image](https://github.com/MEAWWWS/Accounting-and-inventory-control/assets/114382568/01d49144-c666-4117-b89c-942ddf011bc5)
![image](https://github.com/MEAWWWS/Accounting-and-inventory-control/assets/114382568/a51116a6-04e0-4b52-8592-c21b21170113)
![image](https://github.com/MEAWWWS/Accounting-and-inventory-control/assets/114382568/39dceaa6-85be-472d-8ed9-097af8edc6d1)
![image](https://github.com/MEAWWWS/Accounting-and-inventory-control/assets/114382568/8ea5fec8-d91e-4a7d-a16b-4bc2d25ec5a0)


## Функциональность

1. **Поиск оборудования**: поиск производится по инвентарному номеру и адресу, необходимо просто вписать часть инвентарного номера либо адреса.
   
3. **Добавление**: добавление происходит в случае вписания данных в строки (ФИО, инвентарный номер, оборудование, цена, адрес) и нажатии кнопки добавить.
   
4. **Удаление**: удаление происходит при выделении всей строки и нажатии на кнопку удалить.
   
5. **Изменение**: для изменения данных нужно нажать на нужную вам ячейку и вписать новые данные.

   
## Технические детали

-**Разработано на**: WinForms

-**База данных**: SQLite с использованием Entity Framework


## Создание классов ApplicationContext и Worker для связи с БД

``` C#
using Microsoft.EntityFrameworkCore;
namespace Practice1.Classes
{
    public class ApplicationContext1 : DbContext
    {
        public DbSet<Worker> Workers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Practic1.db");
        }
    }
}

using System.ComponentModel.DataAnnotations;
namespace Practice1.Classes
{
    public class Worker
    {
        [Key]
        public int id {  get; set; }
        public string fcs { get; set; }
        public string invNumber { get; set; }
        public string equip { get; set; }
        public float cost { get; set; }
        public string adress { get; set; }

        public Worker()
        {
            
        }
    }
}

Worker представляет отдельную запись в БД, атрибут Key обозначает первичный ключ. ApplicationContext представляет подключение к БД.
```

## Код для создания таблицы Workers SQLite
``` SQLite
CREATE TABLE "Workers" (
	"id"	INTEGER NOT NULL UNIQUE,
	"fcs"	TEXT NOT NULL,
	"invNumber"	TEXT NOT NULL,
	"equip"	TEXT NOT NULL,
	"cost"	REAL NOT NULL,
	"adress"	TEXT NOT NULL,
	PRIMARY KEY("id" AUTOINCREMENT)
)
По порядку: идентификатор, ФИО, инвентарный номер, оборудование, цена, адрес
```

## Автор программы

### Зимин М.
