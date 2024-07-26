using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using InventoryManage;

namespace IM.API.Databse
{
    public class Filebase
    {
        private string _root;
   
        private static Filebase _instance;


        public static Filebase Current
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new Filebase();
                }

                return _instance;
            }
        }

        private Filebase()
        {
          _root = "/Users/kester/temp/Items";

        }
         public int LastID
      {
        get
        {
            if (Items?.Any() ?? false)
            {
                return Items.Select(c => c.Id).Max();
            }
            return 0; 
        }
    }

        public Item AddOrUpdate(Item p)
        {
           
            string path = Path.Combine(_root, $"{p.Id}.json");

            //if the item has been previously persisted
            if(File.Exists(path))
            {
                //blow it up
                File.Delete(path);
            }

            //write the file
            File.WriteAllText(path, JsonConvert.SerializeObject(item));

            //return the item, which now has an id
            return item;
        }

         public List<Item> Items
        {
            get
            {
                var root = new DirectoryInfo(_root);
                var itmz = new List<Item>();
                foreach (var appFile in root.GetFiles())
                {
                    var itm = JsonConvert.DeserializeObject<Item>(File.ReadAllText(appFile.FullName));
                    if (itm!= null){
                        itmz.Add(itm);
                    }
                }
                return itmz;
            }
        }

       
        public Item Delete(string type, string id)
        {
            //TODO: refer to AddOrUpdate for an idea of how you can implement this.
             throw new NotImplementedException();
        }
    }


    // ------------------- FAKE MODEL FILES, REPLACE THESE WITH A REFERENCE TO YOUR MODELS -------- //
    
}
