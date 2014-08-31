package Classes.Services;

import com.google.gson.Gson;

import org.apache.http.HttpRequest;
import org.apache.http.HttpResponse;
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpRequestBase;
import org.apache.http.impl.client.DefaultHttpClient;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.lang.reflect.ParameterizedType;

/**
 * Created by Todd on 7/12/2014.
 */
public class RestfulHttpClient  {
    private HttpClient httpClient;
    private static RestfulHttpClient restfulHttpClient;
    private RestfulHttpClient(){
        httpClient = new DefaultHttpClient();
    }

    public static RestfulHttpClient getInstance(){
        if(restfulHttpClient == null){
            restfulHttpClient = new RestfulHttpClient();
        }

        return restfulHttpClient;
    }

    public <T> RestfulAPIResponse<T> handleRequest(HttpRequestBase request) throws IOException {
        RestfulAPIResponse restfulAPIResponse = null;
        HttpResponse response = httpClient.execute(request);
        if (response.getStatusLine().getStatusCode() != 200) {
            restfulAPIResponse = new RestfulAPIResponse(false, "Failed : HTTP error code : "
                    + response.getStatusLine().getStatusCode(), null);
        } else{
           BufferedReader br = new BufferedReader(
                   new InputStreamReader((response.getEntity().getContent())));

           Gson gson = new Gson();

           restfulAPIResponse = new RestfulAPIResponse(true, "", gson.fromJson(br, new Container<T>().getContents()));
        }



        return restfulAPIResponse;
    }
}
