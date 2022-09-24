import { Component, DefaultIterableDiffer, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { ConfirmDialogComponent } from './confirm-dialog/confirm-dialog.component';
import { Transaction, TransactionColumns } from './model/transaction';
import { TransactionService } from './services/transactions.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  displayedColumns: string[] = TransactionColumns.map((col) => col.key);
  columnsSchema: any = TransactionColumns;
  dataSource = new MatTableDataSource<Transaction>();
  valid: any = {};

  constructor(public dialog: MatDialog, private TransactionService: TransactionService) {}

  ngOnInit() {
    this.TransactionService.getTransactions().subscribe((res: any) => {
      this.dataSource.data = res;
    });
  }

  editRow(row: Transaction) {
    row.isEdit = false;
  }

  updateTransactions() {
    const Transactions = this.dataSource.data;

    this.TransactionService.updateTransactions(Transactions).subscribe(() => {
      alert("Transactions updated!.");
    });
  }

  inputHandler(e: any, id: number, key: string) {
    if (!this.valid[id]) {
      this.valid[id] = {};
    }
    this.valid[id][key] = e.target.validity.valid;
  }

  disableSubmit(id: number) {
    if (this.valid[id]) {
      return Object.values(this.valid[id]).some((item) => item === false);
    }
    return false;
  }
}
