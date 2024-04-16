using Avalonia.Styling;

namespace galnko;

public class pol
{
      public pol(int id, string name, string phone, string rosden, string пол, string скидка)
      {
            this.id = id;
            this.name = name;
            this.phone = phone;
            this.rosden = rosden;
            this.пол = пол;
            this.скидка = скидка;
      }

      public pol()
      {}
      public int id { get; set; }   
      public string name { get; set; }
      public string phone { get; set; }
      public string rosden { get; set; }
      public string пол { get; set; }
      public string скидка { get; set; }
   
}