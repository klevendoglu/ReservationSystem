import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ResourceDto } from '@proxy/resources/dtos/resource';

@Component({
  selector: 'handle-requested-item-modal',
  templateUrl: 'handle-requested-item-modal.component.html',
})
export class HandleRequestedItemModalComponent implements OnInit {
  requestedItemForm: FormGroup;

  @Input() public selectedChildResource: ResourceDto;

  constructor(public activeModal: NgbActiveModal, private fb: FormBuilder) {}

  ngOnInit() {
    this.buildRequestedItemsForm();
  }

  buildRequestedItemsForm() {
    this.requestedItemForm = this.fb.group({
      startDate: [null, [Validators.required]],
      startTime: [{ hour: 0, minute: 0}, Validators.required],
      requestedHours: [null, [Validators.required]],
    });
  }

  returnRequestedItem() {
    if (this.requestedItemForm.invalid) {
      return;
    }
    this.activeModal.close(this.requestedItemForm);
  }
}
