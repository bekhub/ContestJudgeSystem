import {Component, OnInit} from "@angular/core";
import { ResultsService } from "./results.service";
import {SubmissionList} from "../models/submission.model";
import {NgxSpinnerService} from "ngx-spinner";

@Component({
  selector: 'app-results',
  templateUrl: './results.component.html',
  providers: [ResultsService]
})
export class ResultsComponent implements OnInit{

  submissions: SubmissionList[];

  constructor(
    private service: ResultsService,
    private spinner: NgxSpinnerService
  ) {  }

  ngOnInit(): void {
    this.spinner.show();
    this.service.getSubmissions().subscribe((submissions : SubmissionList[]) => this.submissions = submissions)
      .add(() => this.spinner.hide());
  }
}
