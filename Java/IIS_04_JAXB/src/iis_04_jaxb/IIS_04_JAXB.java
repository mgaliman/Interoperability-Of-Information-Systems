package iis_04_jaxb;

import generated.FreeNewsItems;
import java.io.File;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.xml.bind.JAXBContext;
import javax.xml.bind.JAXBException;
import javax.xml.bind.Marshaller;
import javax.xml.bind.Unmarshaller;

public class IIS_04_JAXB {

    public static void main(String[] args) {
        try {
            JAXBContext jc = JAXBContext.newInstance(FreeNewsItems.class);
            Marshaller m = jc.createMarshaller();
            
            Unmarshaller u = jc.createUnmarshaller();
            File file = new File("JAXB.xml");
            if(file.exists() && !file.isDirectory()) { 
                System.out.println("File reached!");
                FreeNewsItems freeNews = (FreeNewsItems) u.unmarshal(file);
                m.marshal(freeNews, System.out);                
            }
        } catch (JAXBException ex) {
            Logger.getLogger(IIS_04_JAXB.class.getName()).log(Level.SEVERE, null, ex);
        }
    }    
}
