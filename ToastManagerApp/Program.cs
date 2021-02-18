using System;
using System.Collections.Generic;
using System.Linq;


namespace ToastManagerApp
{
    class Program
    {
       static void Main() {
     ToastMasterManagement manager = new ToastMasterManagement();
    
    int NoOfInput = int.Parse(Console.ReadLine());
            int Id = 1000;
    
    for(int i = 0; i < NoOfInput; i++){
                Id += 1;
        string Location = Console.ReadLine();
        string Type = Console.ReadLine();
        int NoOfEvents = int.Parse(Console.ReadLine());
        int NoOfYears = int.Parse(Console.ReadLine());
        manager.toastmasters.Add(new ToastMaster(Id,Location, Type, NoOfEvents, NoOfYears));
    }
    
    int choice = int.Parse(Console.ReadLine());
    
    if(choice == 1){
        
        string LocationInput = Console.ReadLine();
        int total = manager.TotalCount(LocationInput);
        if(total > 0){
            Console.WriteLine("Total Count is:" + total);
        }else{
            Console.WriteLine("There are no toastmaster with the given location");
        }
        
    }else if (choice == 2){
        string TypeInput = Console.ReadLine();
        Dictionary<int, string> dict = new Dictionary<int, string>(manager.FindLocation(TypeInput));
       
        if(dict.Count > 0){
            
            foreach(KeyValuePair<int, string> find in dict){
                Console.WriteLine(find.Key + "-" + find.Value);
            }
            
        }else{
            
            Console.WriteLine("There are no toastmaster with the given type");
        }
        
    }
    
  }
}

class ToastMaster{
    
    private int ToastMasterId;
    private string Location;
    private string Type;
    private int NoOfEvents;
    private int NoOfYears;
    
    public ToastMaster(int ToastMasterId, string Location, string Type, int NoOfEvents, int NoOfYears){
            this.ToastMasterId = ToastMasterId;
        this.Location = Location;
        this.Type = Type;
        this.NoOfEvents = NoOfEvents;
        this.NoOfYears = NoOfYears;
    }

        
    
    public int GetToastMasterId(){
        return ToastMasterId;
    }
    
    public string GetLocation(){
        return Location;
    }
    
    public string GetType(){
        return Type;
    }
    public int GetNoOfEvents(){
        return NoOfEvents;
    }
    
    public int GetNoOfYears(){
        return NoOfYears;
    }
    
    
}

class ToastMasterManagement{
    public List<ToastMaster> toastmasters {get; set;}
    
    public ToastMasterManagement(){
        toastmasters = new List<ToastMaster>();
    }
    
    public int TotalCount(string locate){
        
        string check = "";
        int count = 0;
        locate = locate.ToLower();
        for(int i = 0; i < toastmasters.Count; i++){
            
            check = toastmasters[i].GetLocation();
            check = check.ToLower();
            
            if(check.Equals(locate)){
                if(toastmasters[i].GetNoOfEvents() > 10){
                    count++;
                }
            }
            
        }
        return count;
    }
    
    public Dictionary<int,string> FindLocation(string Type){
        Dictionary<int, string> dict = new Dictionary<int, string>();
        Type = Type.ToLower();
        string check = "";
        for(int i = 0; i < toastmasters.Count; i++){
            check = toastmasters[i].GetType().ToLower();
            
            if(check.Equals(Type)){
                dict.Add(toastmasters[i].GetToastMasterId(), toastmasters[i].GetLocation());
            }
            
            
        }
            Dictionary<int, string> dict2 = new Dictionary<int, string>();
            foreach (KeyValuePair<int, string> sorts in dict.OrderBy(i => i.Key)){
                dict2.Add(sorts.Key, sorts.Value);

            }
        
        return dict2;
    }
}


}
