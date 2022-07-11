package hr.myutilities.factory;

import java.io.InputStream;
import javax.xml.stream.XMLEventReader;
import javax.xml.stream.XMLInputFactory;
import javax.xml.stream.XMLStreamException;

public class ParserFactory {
    
    private ParserFactory() {
    }
 
    public static XMLEventReader createStaxParser(InputStream is) throws XMLStreamException {
        XMLInputFactory factory = XMLInputFactory.newFactory();
        XMLEventReader reader = factory.createXMLEventReader(is);
        return reader;
    }
}
