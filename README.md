# weather-web

Chia branch:

  main: Branch chính, chứa mã ổn định và đã được kiểm tra.
  
  dev: Branch phát triển chung, nơi các tính năng mới sẽ được tích hợp trước khi đưa vào main.
  
  backend/{name feature}: Branchlàm việc với phần backend.
  
  frontend/{name feature}: Branch làm việc với phần frontend.
  
  realtime: Branch làm việc với phần xử lý dữ liệu real-time

Thiết lập workflow:

Feature development: Các thành viên sẽ làm việc trên các branch feature của mình.
Pull Request (PR): Khi hoàn thành một tính năng, tạo PR từ branch feature đến branch dev. Các thành viên khác sẽ review và merge vào dev.

Đặt tên file theo chuẩn camelCase nhưng có viết hoa chữ đầu

Cấu trúc thư mục: 

/weather-app

    /backend
        /models
            model-weather.cs
            model-forecast.cs
        /controllers
            controller-weather.cs
            controller-user.cs
        /services
            service-weather.cs
            service-forecast.cs
        /repositories
            repository-weather.cs
            repository-forecast.cs
    /frontend
        /components
            component-weather-display.cshtml
            component-forecast-table.cshtml
        /styles
            style-weather-display.css
            style-forecast-table.css
        /scripts
            script-weather-fetch.js
            script-forecast-update.js
    /realtime
        hub-weather.cs
        hub-notifications.cs
        realtime-weather-update.js
        realtime-notifications.js
