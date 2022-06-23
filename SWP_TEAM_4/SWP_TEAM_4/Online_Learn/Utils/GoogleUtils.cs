using System.Collections.Generic;
using System;
using Microsoft.VisualBasic;

namespace Online_Learn.Utils {
    public class GoogleUtils {
        public static String GOOGLE_CLIENT_ID = "240096817026-hiacplg3lvqrnku3g6ihm26fv3geog3q.apps.googleusercontent.com";
        public static String GOOGLE_CLIENT_SECRET = "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";
        public static String GOOGLE_REDIRECT_URI = "http://localhost:8080/Login/Login_Google";
        public static String GOOGLE_LINK_GET_TOKEN = "https://accounts.google.com/o/oauth2/token";
        public static String GOOGLE_LINK_GET_USER_INFO = "https://www.googleapis.com/oauth2/v1/userinfo?access_token=";
        public static String GOOGLE_GRANT_TYPE = "authorization_code";
        //      public static String getToken(String code)
        //      {
        //          String response = Request.Post(GOOGLE_LINK_GET_TOKEN)
        //              .bodyForm(Form.form().add("client_id", GOOGLE_CLIENT_ID)
        //                  .add("client_secret", GOOGLE_CLIENT_SECRET)
        //                  .add("redirect_uri", GOOGLE_REDIRECT_URI).add("code", code)
        //                  .add("grant_type", GOOGLE_GRANT_TYPE).build())
        //              .execute().returnContent().asString();
        //          JsonObject jobj = new Gson().fromJson(response, JsonObject.class);
        //    String accessToken = jobj.get("access_token").toString().replaceAll("\"", "");
        //    return accessToken;
        //}
        //  public GooglePojo getUserInfo( String accessToken){
        //      String link = GOOGLE_LINK_GET_USER_INFO + accessToken;
        //  String response = Request.Get(link).execute().returnContent().asString();
        //  ObjectMapper mapper = new ObjectMapper();
        //  GooglePojo googlePojo = mapper.readValue(response, GooglePojo.class);
        //      System.out.println(googlePojo);
        //      return googlePojo;
        //    }
        //public UserDetails buildUser(GooglePojo googlePojo)
        //{
        //    boolean enabled = true;
        //    boolean accountNonExpired = true;
        //    boolean credentialsNonExpired = true;
        //    boolean accountNonLocked = true;
        //    List<GrantedAuthority> authorities = new ArrayList<GrantedAuthority>();
        //    authorities.add(new SimpleGrantedAuthority("ROLE_USER"));
        //    UserDetails userDetail = new User(googlePojo.getEmail(),
        //        "", enabled, accountNonExpired, credentialsNonExpired, accountNonLocked, authorities);
        //    return userDetail;
        //}
        //    }
    }
}
