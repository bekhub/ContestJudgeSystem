import { Inject, Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { SubmissionDetail } from "../models/submission.model";
import { Observable } from "rxjs";

@Injectable()
export class SubmissionService {

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string
  ) { }

  getSubmission(id: string) : Observable<any> {
    return this.http.get<SubmissionDetail>(this.baseUrl + 'main/submission/' + id);
  }
}
