using Design_patterns_in_action.Behavioral;
//Auth=>log=>compressor
var compressor = new Compressor(null);
var logger = new Logger(compressor);
var authenticator = new Authenticator(logger);
var server = new WebServer(authenticator);
server.Handler(new HttpRequest() { UserName = "admin", Password = "admin" });