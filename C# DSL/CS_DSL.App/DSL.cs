using System;
using System.Collections;
using System.Collections.Generic;

namespace ReMetalMaxDev {

    using IfCondition = Func<bool>;
    using ExcuteScript = Action;


    public interface Statement {
        void Excute();
    }

    public class MultiStatements {
        LinkedList<Statement> StatementList = new LinkedList<Statement>();

        public void Push(Statement statement) {
            StatementList.AddLast(statement);
        }
        public MultiStatements Statement { get => this; }

        public IfStatement If(IfCondition condition) => new IfStatement() { Container = this };

        public void Excute() {
            foreach (var stat in this.StatementList) {
                stat.Excute();
            }
        }
    }

    public class IfStatement : Statement {
        public IfCondition condition;
        public MultiStatements ExcuteStatements;
        public ElseStatement ElseStatement;
        
        public MultiStatements Container;
        
        public IfStatement Then(ExcuteScript excuteScript) {
            this.Container.Push(this);
            return this;
        }

        public ElseStatement Else() {
            var elseStatement = new ElseStatement() { Container = this.Container };
            this.ElseStatement = elseStatement;
            return elseStatement;
        }

        public MultiStatements Then(MultiStatements statement) {
            ExcuteStatements = statement;
            return Container;
        }

        public void Excute()
        {
            var result = condition();
            if (result) {
                ExcuteStatements.Excute();
            }
            else {
                ElseStatement.Excute();
            }
        }
    }

    public class ElseStatement : Statement {
        public MultiStatements ExcuteStatements;
        
        public MultiStatements Container;

        public MultiStatements Then(ExcuteScript excuteScript) {
            return Container;
        }

        public MultiStatements Then(MultiStatements statement) {
            return Container;
        }

        public void Excute()
        {
            ExcuteStatements.Excute();
        }
    }

    public static class DSL {
        static public MultiStatements DescribeAs { get => new MultiStatements(); }

        static void Test() {
            var statements = DSL.DescribeAs
                .Statement.If(() => true).Then(
                            () => {
                            })
                        .Else().Then(
                            () => {
                            })
                .Statement.If(() => true).Then(
                            DSL.DescribeAs
                                .Statement.If(() => true).Then(() => {})
                        .Else().Then(
                            () => {
                            }));

            statements.Excute();
        }
    }
}
