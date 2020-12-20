import { Language } from '../models/language.model';
import { Submission } from '../models/submission.model';
import { Inject, Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

@Injectable()
export class MainService {

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string
  ) { }

  getLanguages() {
    return this.http.get<Language[]>(this.baseUrl + 'main/languages');
  }

  sendSubmission(submission: Submission) : Promise<any> {
    let model = new FormData();
    model.append('languageId', submission.languageId.toString());
    model.append('sourceCode', submission.sourceCode);
    model.append("checker", submission.checker);
    model.append("checkerType", submission.checkerType.toString());
    submission.files.forEach(x => {
      model.append('inputs', x.input);
      model.append('outputs', x.output);
    });
    return this.http.post(this.baseUrl + 'main/submission', model).toPromise();
  }
}
