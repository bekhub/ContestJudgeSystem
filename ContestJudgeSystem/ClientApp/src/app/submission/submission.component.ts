import { Component } from "@angular/core";
import { SubmissionService } from "./submission.service";
import { SubmissionDetail } from "../models/submission.model";
import { ActivatedRoute, Router } from "@angular/router";
import { Subscription } from "rxjs";
import { NgxSpinnerService } from "ngx-spinner";

@Component({
  selector: 'app-submission',
  templateUrl: './submission.component.html',
  styleUrls: ['./submission.component.css'],
  providers: [SubmissionService],
})

export class SubmissionComponent {

  submission: SubmissionDetail;

  constructor(private activatedRoute: ActivatedRoute,
              private router: Router,
              private service: SubmissionService,
              private spinner: NgxSpinnerService) {
  }

  observing: Subscription;

  ngOnInit() {
    this.spinner.show();
    this.observing = this.activatedRoute.paramMap.subscribe(params => {
      console.log(params);
      this.service.getSubmission(params.get('id')).subscribe(
        (submission: SubmissionDetail) => this.submission = submission
      ).add(() => this.spinner.hide());
    });
  }

  ngOnDestroy() {
    this.observing.unsubscribe();
  }
}
