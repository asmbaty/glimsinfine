//
//  P31Twitter.h
//  SocialNetworking
//
//  Created by Mike on 9/11/10.
//  Copyright 2010 Prime31 Studios. All rights reserved.
//

#import <Foundation/Foundation.h>


typedef enum {
	TwitterRequestLogin,
	TwitterRequestUpdateStatus,
	TwitterRequestCustom
} TwitterRequest;


@class OAToken;

@interface TwitterManager : NSObject
{
	NSString *_consumerKey;
	NSString *_consumerSecret;
    
@private
	NSMutableData *_payload;
	TwitterRequest _requestType;
}
@property (nonatomic, copy) NSString *consumerKey;
@property (nonatomic, copy) NSString *consumerSecret;
@property (nonatomic, retain) NSMutableData *payload;



+ (TwitterManager*)sharedManager;

+ (BOOL)isTweetSheetSupported;

+ (BOOL)userCanTweet;



// these next methods are used by Xauth and Oauth methods
- (NSString*)extractUsernameFromHTTPBody:(NSString*)body;

- (void)completeLoginWithResponseData:(NSString*)data;


- (void)unpauseUnity;

- (BOOL)isLoggedIn;

- (NSString*)loggedInUsername;

- (void)xAuthLoginWithUsername:(NSString*)username password:(NSString*)password;

- (void)showOauthLoginDialog;

- (void)logout;

- (void)postStatusUpdate:(NSString*)status withImageAtPath:(NSString*)path;

- (void)performRequest:(NSString*)methodType path:(NSString*)path params:(NSDictionary*)params;

- (void)showTweetComposerWithMessage:(NSString*)message image:(UIImage*)image link:(NSString*)link;

@end
