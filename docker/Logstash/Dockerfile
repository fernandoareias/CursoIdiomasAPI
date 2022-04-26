FROM docker.elastic.co/logstash/logstash:8.1.2

ENV ELASTICSEARCH_HOST=""
ENV ELASTICSEARCH_PORT=""
ENV SQLSERVER_HOST=""
ENV SQLSERVER_DATABASE=""
ENV SQLSERVER_USER=""
ENV SQLSERVER_PASSWORD=""
ENV PIPELINE_PATH=""
EXPOSE 9600

ADD sqljdbc_9.4 /usr/share/logstash/logstash-core/lib/jars
RUN rm -f /usr/share/logstash/pipeline/logstash.conf
ADD pipeline/ /usr/share/logstash/pipeline/
ADD config/ /usr/share/logstash/config/
RUN mkdir -p /usr/share/logstash/queries
ADD queries/ /usr/share/logstash/queries/
RUN mkdir -p /usr/share/logstash/last_run_metadata

CMD /usr/share/logstash/bin/logstash -f ${PIPELINE_PATH}
