package server.enumeration;

import java.util.Optional;

public enum TagType {
    CITY_NAME("GradIme"),
    TEMPERATURE("Temp"),
    MOISTURE("Vlaga"),
    PRESSURE("Tlak"),
    WIND_DIRECTION("VjetarSmjer"),
    WIND_SPEED("VjetarBrzina"),
    DESCRIPTION("Vrijeme");

    private final String name;

    private TagType(String name) {
        this.name = name;
    }

    public static Optional<TagType> from(String name) {
        for (TagType value : values()) {
            if (value.name.equals(name)) {
                return Optional.of(value);
            }
        }
        return Optional.empty();
    }
}
