using Azure.Messaging;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design.Serialization;
using System.Text;
using TurboAzApp.Extensions;
using TurboAzApp.Models.DbContexts;
using TurboAzApp.Models.Entity;
using TurboAzApp.Models.Stables;

namespace TurboAzApp
{
    internal static class Program
    {
        static CarDbContext db = new CarDbContext();
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            

            Extension.PrintLine("Welcome to Turbo.Az!");
        l1:
            Enum menuOption = Extension.ChooseOption<MenuOption>("Choose an Option: ");
            switch (menuOption)
            {
                // Car
                case MenuOption.NewAnnouncement:
                    CarAdd();
                    Console.Clear();
                    goto l1;
                case MenuOption.CarEdit:
                    CarEdit();
                    Console.Clear();
                    goto l1;
                case MenuOption.CarDelete:
                    CarDelete();
                    Console.Clear();    
                    goto l1;
                case MenuOption.CarGetById:
                    CarGetById();
                    Console.ReadKey();
                    Console.Clear();
                    goto l1;
                case MenuOption.CarGetAll:
                    CarGetAll();
                    Console.ReadKey();
                    Console.Clear();
                    goto l1;


                    // Model
                case MenuOption.ModelAdd:
                    ModelAdd();
                    Console.Clear();
                    goto l1;
                case MenuOption.ModelEdit:
                    ModelEdit();
                    goto l1;
                case MenuOption.ModelDelete:
                    ModelDelete();
                    Console.Clear();
                    goto l1;
                case MenuOption.ModelGetById:
                    ModelGetById();
                    Console.ReadKey();
                    Console.Clear();
                    goto l1;
                case MenuOption.ModelGetAll:
                    ModelGetAll();
                    Console.ReadKey();
                    Console.Clear();
                    goto l1;


                //Brand

                case MenuOption.BrandAdd:
                    BrandAdd();
                    db.SaveChanges();
                    Console.Clear();
                    goto l1;
                case MenuOption.BrandEdit:
                    BrandEdit();
                    Console.Clear();
                    goto l1;
                case MenuOption.BrandDelete:
                    BrandDelete();
                    Console.Clear();
                    goto l1;
                case MenuOption.BrandGetById:
                    BrandGetById();
                    Console.ReadKey();
                    Console.Clear();
                    goto l1;
                case MenuOption.BrandGetAll:
                    BrandGetAll();
                    Console.ReadKey();
                    Console.Clear();
                    goto l1;  


                //Environment

                case MenuOption.Close:
                    Console.WriteLine();
                    Extension.Print("Thanks for using our Program!");
                    Environment.Exit(0);
                    break;
            }
            
        }
        
        //Brand
        public static void BrandAdd()
        {
            Brand brand = new Brand();
            brand.Name = Extension.ReadString("enter Brand Name: ");
            brand.CreatedBy = 1;
            brand.CreatedAt = DateTime.Now;

            db.Brands.Add(brand);
        }
        public static void BrandEdit()
        {
            BrandGetAll();
            l1:
            int id = (int)Extension.Read<int>("Please give an Id to edit: ")!;
            
            var brand = db.Brands.FirstOrDefault(b => b.Id == id);
            
            if (brand is not null)
            {
                brand.Name = Extension.ReadString("enter new Brand Name: ");
                brand.LastModifiedAt = DateTime.Now;
                brand.LastModifiedBy = 1;
            }
            else
            {
                Extension.PrintLine("Please give a valid id!", MessageType.Error);
                goto l1;
            }
            db.SaveChanges();
        }
        public static void BrandDelete()
        {
            BrandGetAll();
        l1:
            int id = (int)Extension.Read<int>("Please give an Id to delete: ")!;

            var brand = db.Brands.FirstOrDefault(b => b.Id == id);
            

            if (brand is not null)
            {
                brand.DeletedAt = DateTime.Now;
                brand.DeletedBy = 1;
            }
            else
            {
                Extension.PrintLine("Please give a valid id!", MessageType.Error);
                goto l1;
            }
            db.SaveChanges();

        }
        public static void BrandGetAll()
        {

            if (!db.Brands.Any())
            {
                Extension.PrintLine("There is no Brand!",MessageType.Error);
                BrandAdd();
            }
            db.SaveChanges();
            var brands = db.Brands.ToList();
            foreach ( var brand in brands )
            {
                    Console.WriteLine($"{brand.Id}) {brand.Name}");
                
            }
        }
        public static void BrandGetById()
        {
            if (!db.Brands.Any())
            {
                Extension.PrintLine("There is no Brand!", MessageType.Error);
                BrandAdd();
            }
            db.SaveChanges();
            l1:
            int id = (int)Extension.Read<int>("Please give a number to see the following brand: ")!;
            

            if (db.Brands.Any(m => m.Id == id))
            {
                var brand = db.Brands.FirstOrDefault(db => db.Id == id && db.DeletedAt == null);
                Console.WriteLine($"{brand?.Id}) {brand?.Name}");
            }
            else
            {
                Extension.PrintLine("Please give a valid id!",MessageType.Error);
                goto l1;
            }
        }

        //Model
        public static void ModelAdd()
        {
            Model model = new Model();
            model.Name = Extension.ReadString("Enter the model name: ");
            model.CreatedBy = 1;
            model.CreatedAt = DateTime.Now;


            BrandGetAll();
            l1:
            model.BrandId = (int)Extension.Read<int>("Enter the Brand id: ")!;
            var brand = db.Brands.FirstOrDefault(m => m.Id == model.BrandId);
            if (brand is null)
            {
                Extension.PrintLine("You must give a valid model! ", MessageType.Error);
                goto l1;
            }
            db.Models.Add(model);
        }
        public static void ModelDelete()
        {
            ModelGetAll();
            int id = (int)Extension.Read<int>("Give an Id to edit a model: ")!;
            var model = db.Models.FirstOrDefault(m => m.Id == id);
            if (model is not null)
            {
                model.DeletedAt = DateTime.Now;
                model.DeletedBy = 1;

            }
            db.SaveChanges();
        }
        public static void ModelEdit()
        {
            ModelGetAll();

            int id = (int)Extension.Read<int>("Give an Id to edit a model: ")!;
            var model = db.Models.FirstOrDefault(m => m.Id == id);
            if ( model is not null)
            {
                model.LastModifiedAt = DateTime.Now;
                model.LastModifiedBy = 1;

                model.Name = Extension.ReadString("Enter new name of Model: ");
            l1:
                model.BrandId = (int)Extension.Read<int>("Enter the new Brand id: ")!;
                var brand = db.Brands.FirstOrDefault(m => m.Id == model.BrandId);
                if (brand is null)
                {
                    Extension.PrintLine("You must give a valid model! ", MessageType.Error);
                    goto l1;
                }
            }
            db.SaveChanges();
        }
        public static void ModelGetAll()
        {
            if (!db.Models.Any())
            {
                Extension.PrintLine("There is no Model!", MessageType.Error);
                ModelAdd();
            }
            db.SaveChanges();

            var results = (from m in db.Models
                        join b in db.Brands on m.BrandId equals b.Id
                        select new {m.Id, m.Name, BrandId = b.Id, BrandName = b.Name}).ToList();


            
            foreach ( var model in results )
            {
                    Console.WriteLine($"{model.Id}) {model.Name}, {model.BrandId}, {model.BrandName}");
               
            }
        }
        public static void ModelGetById()
        {
            if (!db.Models.Any())
            {
                Extension.PrintLine("There is no Model!", MessageType.Error);
                ModelAdd();
            }
            db.SaveChanges();
        l1:
            int id = (int)Extension.Read<int>("Please give a number to see the following Model: ")!;
            var model = (from m in db.Models
                         join b in db.Brands on m.BrandId equals b.Id
                         where m.Id == id
                         select new { m.Id, m.Name, BrandId = b.Id, BrandName = b.Name }).FirstOrDefault();

            if (model is null)
            {
                Extension.PrintLine("Please give a valid id!", MessageType.Error);
                goto l1;
            }

            Console.WriteLine($"{model?.Id}) {model?.Name}, {model?.BrandId}");

            
        }

        //Car
        public static void CarAdd()
        {
            Car entity = new Car();

            //Model
            ModelGetAll();
            l1:
            int modelId = (int)Extension.Read<int>("Enter the Model id: ")!;
            var model = db.Models.FirstOrDefault(m => m.Id == modelId);
            if (model is null)
            {
                Extension.PrintLine("You must give a valid model! ", MessageType.Error);
                goto l1;
            }
            entity.ModelId = modelId;

            
            

            Console.Clear();
            var category = Extension.ChooseOption<Categories>("Enter the category: ");
            entity.Category = category;

            Console.Clear();
            var fuelType = Extension.ChooseOption<FuelTypes>("Enter the fuel type: ");
            entity.FuelType = fuelType;

            Console.Clear();
            var transmission = Extension.ChooseOption<Transmissions>("Enter the transmission: ");
            entity.Transmission = transmission;

            Console.Clear();
            var gears = Extension.ChooseOption<Gears>("Enter the gearbox: ");
            entity.Gear = gears;

            Console.Clear();
            l2:
            entity.March = (decimal)Extension.Read<decimal>("Enter the March: ")!;
            if (entity.March < 0)
            {
                Extension.PrintLine("March can not be negative!", MessageType.Error);
                goto l2;
            }

            l3:
            entity.Price = (decimal)Extension.Read<decimal>("Enter the Price: ")!;
            if (entity.Price < 0)
            {
                Extension.PrintLine("Price can not be negative!", MessageType.Error);
                goto l3;
            }
            l4:
            entity.Year = (int)Extension.Read<int>("Enter the Year: ")!;
            if (entity.Year < 1900)
            {
                Extension.PrintLine("Year must be greater than 1900!", MessageType.Error);
                goto l4;
            }
            entity.CreatedAt = DateTime.Now;
            entity.CreatedBy = 1;

            db.Cars.Add(entity);
            db.SaveChanges();
            
        }
        public static void CarDelete()
        {
            CarGetAll();
            int id = (int)Extension.Read<int>("Give an Id to edit a Car: ")!;
            var car = db.Cars.FirstOrDefault(m => m.Id == id);
            if (car is not null)
            {
                car.DeletedAt = DateTime.Now;
                car.DeletedBy = 1;

            }
            db.SaveChanges();
        }
        public static void CarEdit()
        {
            CarGetAll();
            l1:
            int id = (int)Extension.Read<int>("Enter an Id to Edit a Car: ")!;
            var car = db.Cars.FirstOrDefault(m => m.Id == id);  
            if (car == null) 
            {
                Extension.PrintLine("Please give a valid number!",MessageType.Error);
                goto l1;
            }
            //Model
            ModelGetAll();
        l2:
            int modelId = (int)Extension.Read<int>("Enter the new Model id: ")!;
            var model = db.Models.FirstOrDefault(m => m.Id == modelId);
            if (model is null)
            {
                Extension.PrintLine("You must give a valid model! ", MessageType.Error);
                goto l2;
            }
            car.ModelId = modelId;




            Console.Clear();
            var category = Extension.ChooseOption<Categories>("Enter the new category: ");
            car.Category = category;

            Console.Clear();
            var fuelType = Extension.ChooseOption<FuelTypes>("Enter the new fuel type: ");
            car.FuelType = fuelType;

            Console.Clear();
            var transmission = Extension.ChooseOption<Transmissions>("Enter the new transmission: ");
            car.Transmission = transmission;

            Console.Clear();
            var gears = Extension.ChooseOption<Gears>("Enter the new gearbox: ");
            car.Gear = gears;

            Console.Clear();
        l3:
            car.March = (decimal)Extension.Read<decimal>("Enter the new March: ")!;
            if (car.March < 0)
            {
                Extension.PrintLine("March can not be negative!", MessageType.Error);
                goto l3;
            }

        l4:
            car.Price = (decimal)Extension.Read<decimal>("Enter the new Price: ")!;
            if (car.Price < 0)
            {
                Extension.PrintLine("Price can not be negative!", MessageType.Error);
                goto l4;
            }
        l5:
            car.Year = (int)Extension.Read<int>("Enter the new Year: ")!;
            if (car.Year < 1900)
            {
                Extension.PrintLine("Year must be greater than 1900!", MessageType.Error);
                goto l5;
            }
            car.LastModifiedAt = DateTime.Now;
            car.LastModifiedBy = 1;

            
            db.SaveChanges();
        }
        public static void CarGetAll()
        {
            if (!db.Cars.Any())
            {
                Extension.PrintLine("There is no Car!",MessageType.Error);
                CarAdd();
            }
            var results = (from c in db.Cars
                          join m in db.Models on c.ModelId equals m.Id
                          join b in db.Brands on m.BrandId equals b.Id
                          select new { c.Id, c.ModelId,ModelName = m.Name, BrandId = b.Id, c.Category, c.Gear, c.FuelType, c.Transmission, c.March, c.Year }).ToList();
            foreach ( var car in results )
            {
                Console.WriteLine($"{car.Id}) {car.ModelId}, {car.ModelName}, {car.BrandId}, {car.Category}, {car.Gear}, {car.FuelType}, {car.Transmission}, {car.March}, {car.Year}");
            }
        }
        public static void CarGetById() 
        {
            if (!db.Cars.Any())
            {
                Extension.PrintLine("There is no Car!", MessageType.Error);
                ModelAdd();
            }
            db.SaveChanges();
        l1:
            int id = (int)Extension.Read<int>("Please give a number to see the following Car: ")!;

            var model =    (from c in db.Cars
                           join m in db.Models on c.ModelId equals m.Id
                           join b in db.Brands on m.BrandId equals b.Id
                           where c.Id == id
                           select new { c.Id, c.ModelId, ModelName = m.Name, BrandId = b.Id, c.Category, c.Gear, c.FuelType, c.Transmission, c.March, c.Year }).FirstOrDefault();

            if (model is null)
            {
                Extension.PrintLine("Please give a valid id!", MessageType.Error);
                goto l1;
            }
            Console.WriteLine($"{model?.Id}) {model?.ModelId}, {model?.ModelName}, {model?.BrandId}, {model?.Category}, {model?.Gear}, {model?.FuelType}, {model?.Transmission}, {model?.March}, {model?.Year}");
        }


    }
}
