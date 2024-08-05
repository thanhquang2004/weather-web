namespace backend.models
{
    public class WeatherModel
    {
        public Location Location { get; set; }
        // class chua Location Data ( thong tin vi tri )
        public Current Current { get; set; }
        // class chua Current Data  ( thoi tiet hien tai )
        public Forecast Forecast { get; set; }
        // class chuaw Forecast Data ( du bao thoi tiet )
    }

    public class Location
    {
        public string name { get; set; }
        // Biến chứa tên thành phố EX : London , Hanoi ...
        public string country { get; set; }
        // Biến chứa tên quốc gia
        public string localtime { get; set; }
        // Biến chứa thời gian của vị trí được chọn
    }

    public class Condition
    {
        public string text { get; set; }
        // Biến chứa thông tin thời tiết : EX : Cloudy , Moderate rain
        public string icon { get; set; }
        // Dùng để chọn icon thời tiết
    }

    public class Current
    {
        public float temp_c { get; set; }
        // Nhiệt độ C
        public float temp_f { get; set; }
        // Nhiệt độ F
        public int is_day { get; set; }
        // Biến chứa thông tin ngày đêm 1 : ngày  0 : đêm
        public float wind_kph { get; set; }
        // Biến chứa vận tốc gió 
        public int humidity { get; set; }
        // Biến chứa độ ẩm
        public float vis_km { get; set; }
        // Biến chứa tầm nhìn
        public Condition condition { get; set; }
        // class chứa thông tin thời tiết đề cập phía trên
    }
    public class Forecast
    {
        public List<ForecastDay> forecastday { get; set; }
        //class chứa thông tin dự báo
    }
    public class ForecastDay
    {
        public string date { get; set; }
        // Ngày dự đoán
        public Day day { get; set; }
        // class chứa thông tin gồm độ F độ C và thông tin thời tiết
        public List<Hour> hour { get; set; }
        // danh thời tiết theo từng giờ
    }
    public class Hour
    {
        public string time { get; set; }
        public float temp_c { get; set; }
        public float temp_f { get; set; }
        public int is_day { get; set; }
        public Condition condition { get; set; }
    }
    public class Day
    {
        public float avgtemp_c { get; set; }
        public float avgtemp_f { get; set; }
        public Condition condition { get; set; }
    }
}


