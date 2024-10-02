Before do
  Selenium::WebDriver::Chrome::Service.driver_path= "C:\\BrowserDrivers\\chromedriver.exe"
  $page_manager.browser = Watir::Browser.new :chrome
  $page_manager.browser.window.maximize
end

After do |scenario|
  # $page_manager.browser.cookies.clear
  if scenario.failed?
    expand_button = $page_manager.browser.div(:xpath => "//span[@id='lblMessage']/div/div[1]/div[2]")
    sleep 3
    if expand_button.present?
      expand_button.click
    end
    location_name = ""
    unless scenario.location.nil?
      location_name = scenario.location.to_s.gsub("/","_").gsub(":","_")
    end
    screenshot_file = "screenshot/#{scenario.name}-#{location_name}-#{Time.now.strftime('%Y%m%d-%H%M%S')}.png"
    $page_manager.browser.driver.save_screenshot(screenshot_file)
    $page_manager.browser.close
  end
  $page_manager.browser.close
end

at_exit do
  $client.cerrarConexion unless $client.nil?
end