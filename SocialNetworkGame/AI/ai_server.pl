% Libraries
:- use_module(library(http/thread_httpd)).
:- use_module(library(http/http_dispatch)).
:- use_module(library(http/http_parameters)).
:- use_module(library(http/http_open)).
:- use_module(library(http/http_cors)).
:- use_module(library(date)).
:- use_module(library(random)).
:- use_module(library(http/http_client)).
:- use_module(library(http/http_ssl_plugin)).

% JSON Libraries
:- use_module(library(http/json_convert)).
:- use_module(library(http/http_json)).
:- use_module(library(http/json)).
:- use_module(library(http/http_open)).

% Server startup                          
start_server :-
    load_local_modules,
    server_port(Port),
    certificate_file_path(Certificate_Path),
    key_file_path(Key_Path),
    http_server(http_dispatch,
                [ port(Port),
                  ssl([ certificate_file(Certificate_Path),
                        key_file(Key_Path)
                      ])
                ]),
    asserta(port(Port)).

% Shutdown server
stopServer :-
        retract(port(Port)),
        http_stop_server(Port,_).

% Services
load_local_modules :-
    consult(ai_server_config),  % Loads server's configuration
    consult(services/geral_use),
    consult(services/compute_socialnetwork_size).

% Server init
:- start_server.
