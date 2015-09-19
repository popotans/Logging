namespace csharp Logging.ThriftContract   #  ע��1

struct TLogEntity {   #  ע��2 
    1: string Title 
    2: string Message 
    3: byte   Level 
    4: i64    Time 
	5: string    Source
	6: i32       Thread
    7: map<string,string> Tags
  }

  struct TLogPackage {   #  ע��2 
    1:i64		IP
	2:i32    AppId
	3:list<TLogEntity> Items
  }

  


service LogTransferService {  #  ע��3 
   
   void Log(1:TLogPackage logPackage)  
}
