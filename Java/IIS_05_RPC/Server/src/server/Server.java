package server;

import java.io.IOException;
import org.apache.xmlrpc.XmlRpcException;
import org.apache.xmlrpc.server.PropertyHandlerMapping;
import org.apache.xmlrpc.server.XmlRpcServer;
import org.apache.xmlrpc.server.XmlRpcServerConfigImpl;
import org.apache.xmlrpc.webserver.WebServer;
import server.logic.Parser;

public class Server {
    public static void main(String[] args) throws XmlRpcException, IOException {
        System.out.println("Creating server ...");
        WebServer server = new WebServer(8080);
        
        XmlRpcServer xmlServer = server.getXmlRpcServer();
        PropertyHandlerMapping phm = new PropertyHandlerMapping();
        phm.addHandler("Parser", Parser.class);
        xmlServer.setHandlerMapping(phm);
        
        //config
        XmlRpcServerConfigImpl config = (XmlRpcServerConfigImpl) xmlServer.getConfig();
        config.setEnabledForExceptions(true);
        config.setContentLengthOptional(false);
        config.setEnabledForExtensions(true);
        
        System.out.println("Sarting server ...");
        server.start();
        System.out.println("Server started.");
    }
    
    
}
