package server.model;

import javax.xml.bind.annotation.XmlAttribute;
import javax.xml.bind.annotation.XmlElement;

public class City {

    @XmlAttribute
    @XmlElement(name = "GradIme")
    private String cityName;
    @XmlElement(name = "Temp")
    private String temperature;
    @XmlElement(name = "Vlaga")
    private String moisture;
    @XmlElement(name = "Tlak")
    private String pressure;
    @XmlElement(name = "VjetarSmjer")
    private String windDirection;
    @XmlElement(name = "VjetarBrzina")
    private String windSpeed;
    @XmlElement(name = "Vrijeme")
    private String description;

    public City() {
    }

    public City(String cityName, String temperature, String description) {
        this.cityName = cityName;
        this.temperature = temperature;
        this.description = description;
    }

    public String getCityName() {
        return cityName;
    }

    public void setCityName(String cityName) {
        this.cityName = cityName;
    }

    public String getTemperature() {
        return temperature;
    }

    public void setTemperature(String temperature) {
        this.temperature = temperature;
    }

    public String getMoisture() {
        return moisture;
    }

    public void setMoisture(String moisture) {
        this.moisture = moisture;
    }

    public String getPressure() {
        return pressure;
    }

    public void setPressure(String pressure) {
        this.pressure = pressure;
    }

    public String getWindDirection() {
        return windDirection;
    }

    public void setWindDirection(String windDirection) {
        this.windDirection = windDirection;
    }

    public String getWindSpeed() {
        return windSpeed;
    }

    public void setWindSpeed(String windSpeed) {
        this.windSpeed = windSpeed;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    @Override
    public String toString() {
        return "City name = " + cityName + 
                "\nTemperature = " + temperature + 
                "\nMoisture = " + moisture + 
                "\nPressure = " + pressure +
                "\nWind direction = " + windDirection + 
                "\nWind speed = " + windSpeed + 
                "\nDescription = " + description;
    }

}
