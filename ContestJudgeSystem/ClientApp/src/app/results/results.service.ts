import { SubmissionList } from '../models/submission.model';
import { Inject, Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

@Injectable()
export class ResultsService {

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string
  ) { }

  getSubmissions() : Observable<any>{
    return this.http.get<SubmissionList[]>(this.baseUrl + 'main/submissions');
  }
}
