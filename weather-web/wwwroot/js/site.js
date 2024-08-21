<script>
    function updateTime() {
        const timeElement = document.getElementById('current-time');
    const now = new Date(); // Get the current date and time from the user's device

    // Format the date (yyyy-MM-dd)
    const year = now.getFullYear();
    const month = String(now.getMonth() + 1).padStart(2, '0'); // Months are 0-based
    const day = String(now.getDate()).padStart(2, '0');

    // Format the time (HH:mm:ss)
    const hours = String(now.getHours()).padStart(2, '0');
    const minutes = String(now.getMinutes()).padStart(2, '0');
    const seconds = String(now.getSeconds()).padStart(2, '0');

    // Combine date and time in the format yyyy-MM-dd HH:mm:ss
    const formattedDateTime = `${year}-${month}-${day} ${hours}:${minutes}:${seconds}`;

    // Update the displayed time
    timeElement.textContent = formattedDateTime;
    }

    // Update the time immediately on page load
    updateTime();

    // Then update the time every second
    setInterval(updateTime, 1000);
</script>
