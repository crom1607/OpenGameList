import { Injectable } from "@angular/core";
import { Http, Response } from "@angular/http";
import { Observable } from "rxjs/Observable";
import { Item } from "./item";

/*
Injectable decorator, declaring that ours is an
Injectable class. Doing this will attach a set of metadata to our class that will
be consumed by the DI system upon instantiation. Basically, what we're doing
here is telling the DI injector that the constructor parameter(s) should be
instantiated using their declared type(s). The TypeScript code allows a very
fluent syntax to achieve this result at constructor level,
*/
@Injectable()
export class ItemService{
    constructor(private http: Http) {

    }

    private baseUrl = "api/Items/";   //web api Base Url
    // calls the [GET] /api/items/GetLatest/{n} Web API method to retrieve the latest items.
    getLatest(num?: number) {
        var url = this.baseUrl + "getLatest/";
        if (num != null) { url += num; }
        return this.http.get(url)
            .map(response => response.json())
            .catch(this.handleError);
    }

    //calls the [GET] / api / items / GetMostViewed / { n } Web API method to retrieve the most viewed items.
    getMostViewed (num?: number) { 
        var url= this.baseUrl + "GetMostViewed/";
        if (num != null) { url += num; }
        return this.http.get(url)
            .map(Response => Response.json())
            .catch(this.handleError);
    }

    getRandom(num?: number) {
        var url=this.baseUrl += "gerRandom/";
        if (num != null) {
            url+= num;
        }
        return this.http.get(url)
            .map(Response => Response.json())
            .catch(this.handleError);
    }

    get(id: number) {
        if (id == null) {
            throw new Error("id is required");
        }
        var url = this.baseUrl += "get/" + id;
        return this.http.get(url)
            .map(res => <Item>res.json())
            .catch(this.handleError);

    }

    private handleError(error: Response) {
        // output errors to the console.
        console.error(error);
        return Observable.throw(error.json().error || "Server error");
    }

}