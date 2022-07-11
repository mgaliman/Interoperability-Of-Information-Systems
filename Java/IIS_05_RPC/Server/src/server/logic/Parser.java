package server.logic;

import hr.myutilities.factory.ParserFactory;
import hr.myutilities.factory.UrlConnectionFactory;
import java.io.IOException;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.text.ParseException;
import java.util.ArrayList;
import java.util.List;
import java.util.Optional;
import javax.xml.stream.XMLEventReader;
import javax.xml.stream.XMLStreamConstants;
import javax.xml.stream.XMLStreamException;
import javax.xml.stream.events.Characters;
import javax.xml.stream.events.StartElement;
import javax.xml.stream.events.XMLEvent;
import server.enumeration.TagType;
import server.model.City;

public class Parser {

    private static final String RSS_URL = "https://vrijeme.hr/hrvatska_n.xml";

    public String parse(String cityName) throws IOException, XMLStreamException, ParseException {
        List<City> cities = new ArrayList<>();
        HttpURLConnection con = UrlConnectionFactory.getHttpUrlConnection(RSS_URL);

        try ( InputStream is = con.getInputStream()) {
            XMLEventReader reader = ParserFactory.createStaxParser(is);

            Optional<TagType> tagType = Optional.empty();
            City city = null;
            StartElement startElement = null;
            while (reader.hasNext()) {
                XMLEvent event = reader.nextEvent();
                switch (event.getEventType()) {
                    case XMLStreamConstants.START_ELEMENT:
                        startElement = event.asStartElement();
                        String qName = startElement.getName().getLocalPart();
                        tagType = TagType.from(qName);

                        if (tagType.isPresent() && tagType.get() == TagType.CITY_NAME) {
                            city = new City();
                            cities.add(city);
                        }
                        break;
                    case XMLStreamConstants.CHARACTERS:
                        if (tagType.isPresent()) {
                            Characters characters = event.asCharacters();
                            String data = characters.getData().trim();
                            switch (tagType.get()) {
                                case CITY_NAME:
                                    if (city != null && !data.isEmpty()) {
                                        city.setCityName(data);
                                    }
                                    break;
                                case TEMPERATURE:
                                    if (city != null && !data.isEmpty()) {
                                        city.setTemperature(data);
                                    }
                                    break;
                                case MOISTURE:
                                    if (city != null && !data.isEmpty()) {
                                        city.setMoisture(data);
                                    }
                                    break;
                                case PRESSURE:
                                    if (city != null && !data.isEmpty()) {
                                        city.setPressure(data);
                                    }
                                    break;
                                case WIND_DIRECTION:
                                    if (city != null && !data.isEmpty()) {
                                        city.setWindDirection(data);
                                    }
                                    break;
                                case WIND_SPEED:
                                    if (city != null && !data.isEmpty()) {
                                        city.setWindSpeed(data);
                                    }
                                    break;
                                case DESCRIPTION:
                                    if (city != null && !data.isEmpty()) {
                                        city.setDescription(data);
                                    }
                                    break;
                            }
                        }
                        break;
                }
            }
        }
        for (City element : cities) {
            if (element.getCityName().equals(cityName)) {
                return element.toString();
            }
        }
        return "No such city!";
    }
}
